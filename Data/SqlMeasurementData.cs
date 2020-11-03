using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AquaLog.Data
{
    public class SqlMeasurementData : IMeasurementData
    {
        private readonly AquaLogDbContext _db;

        public SqlMeasurementData(AquaLogDbContext db)
        {
            _db = db;
        }
        public async Task<Measurement> Add(Measurement newMeasurement)
        {
            await _db.AddAsync(newMeasurement);
            return newMeasurement;
        }

        public async Task<int> Commit()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<Measurement> Delete(int id)
        {
            var measurement = await GetById(id);
            if(measurement != null)
            {
                _db.Remove(measurement);
            }
            return measurement;
        }

        public async Task<Measurement> GetById(int? id)
        {
            return await _db.Measurements.FindAsync(id);
        }

        public async Task<Measurement> Update(Measurement updatedMeasurement)
        {
            var entity = await Task.FromResult(_db.Measurements.Attach(updatedMeasurement));
            entity.State = EntityState.Modified;
            return updatedMeasurement;
        }

        public async Task<IEnumerable<Measurement>> GetMeasurementsForRange(DateTime startDate, DateTime endDate)
        {
            var query = await Task.FromResult(from m in _db.Measurements
                        where (m.Log.Date >= startDate && m.Log.Date <= endDate)
                        orderby m.Log.Date
                        select m);
            return query;
        }

    }
}