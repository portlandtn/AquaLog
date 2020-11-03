using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AquaLog.Data
{
    public class SqlAquariumData : IAquariumData
    {
        private readonly AquaLogDbContext _db;

        public SqlAquariumData(AquaLogDbContext db)
        {
            _db = db;
        }
        public async Task<Aquarium> Add(Aquarium newAquarium)
        {
            await _db.AddAsync(newAquarium);
            return newAquarium;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<Aquarium> Delete(int id)
        {
            var aquarium = await GetById(id);
            if(aquarium != null)
            {
                _db.Remove(aquarium);
            }
            return aquarium;
        }

        public async Task<IEnumerable<Aquarium>> GetAquariumsByName(string name)
        {
            var query = await Task.FromResult(from a in _db.Aquariums
                        where a.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby a.Name
                        select a);
            return query;
        }

        public async Task<Aquarium> GetById(int id)
        {
            return await _db.Aquariums.FindAsync(id);
        }

        public async Task<Aquarium> Update(Aquarium updatedAquarium)
        {
            var entity = await Task.FromResult(_db.Aquariums.Attach(updatedAquarium));
            entity.State = EntityState.Modified;
            return updatedAquarium;
        }
    }
}