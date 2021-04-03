using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AquaLog.Data
{
    public class SqlMeasurementKeyData : IMeasurementKeyData
    {
        private readonly AquaLogDbContext _db;

        public SqlMeasurementKeyData(AquaLogDbContext db)
        {
            _db = db;
        }
        public async Task<MeasurementKey> Add(MeasurementKey newMeasurementKey)
        {
            await _db.AddAsync(newMeasurementKey);
            return newMeasurementKey;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<MeasurementKey> Delete(int id)
        {
            var measurementKey = await GetById(id);
            if(measurementKey != null)
            {
                _db.Remove(measurementKey);
            }
            return measurementKey;
        }

        public async Task<IEnumerable<MeasurementKey>> GetMeasurementKeysByName(string name)
        {
            var query = await Task.FromResult(from mk in _db.MeasurementKeys
                        where mk.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby mk.Name
                        select mk);
            return query;
        }

        public async Task<MeasurementKey> GetById(int id)
        {
            return await _db.MeasurementKeys.FindAsync(id);
        }

        public async Task<MeasurementKey> Update(MeasurementKey updatedMeasurementKey)
        {
            var entity = await Task.FromResult(_db.MeasurementKeys.Attach(updatedMeasurementKey));
            entity.State = EntityState.Modified;
            return updatedMeasurementKey;
        }
    }
}