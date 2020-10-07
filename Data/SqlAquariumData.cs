using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AquaLog.Data
{
    public class SqlAquariumData : IAquariumData
    {
        private readonly AquaLogDbContext _db;

        public SqlAquariumData(AquaLogDbContext db)
        {
            _db = db;
        }
        public Aquarium Add(Aquarium newAquarium)
        {
            _db.Add(newAquarium);
            return newAquarium;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Aquarium Delete(int id)
        {
            var aquarium = GetById(id);
            if(aquarium != null)
            {
                _db.Remove(aquarium);
            }
            return aquarium;
        }

        public IEnumerable<Aquarium> GetAquariumsByName(string name)
        {
            var query = from a in _db.Aquariums
                        where a.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby a.Name
                        select a;
            return query;
        }

        public Aquarium GetById(int id)
        {
            return _db.Aquariums.Find(id);
        }

        public Aquarium Update(Aquarium updatedAquarium)
        {
            var entity = _db.Aquariums.Attach(updatedAquarium);
            entity.State = EntityState.Modified;
            return updatedAquarium;
        }
    }
}