using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace AquaLog.Data
{
    public class SqlMeasurementData : IMeasurementData
    {
        private readonly AquaLogDbContext _db;

        public SqlMeasurementData(AquaLogDbContext db)
        {
            _db = db;
        }
        public Measurement Add(Measurement newMeasurement)
        {
            _db.Add(newMeasurement);
            return newMeasurement;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Measurement Delete(int id)
        {
            var measurement = GetById(id);
            if(measurement != null)
            {
                _db.Remove(measurement);
            }
            return measurement;
        }

        public Measurement GetById(int? id)
        {
            return _db.Measurements.Find(id);
        }

        public Measurement Update(Measurement updatedMeasurement)
        {
            var entity = _db.Measurements.Attach(updatedMeasurement);
            entity.State = EntityState.Modified;
            return updatedMeasurement;
        }

        public IEnumerable<Measurement> GetMeasurementsForRange(DateTime startDate, DateTime endDate)
        {
            var query = from m in _db.Measurements
                        where (m.Log.Date >= startDate && m.Log.Date <= endDate)
                        orderby m.Log.Date
                        select m;
            return query;
        }

    }
}