using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AquaLog.Data
{
    public class SqlMeasurementKeyData : IMeasurementKeyData
    {
        private readonly AquaLogDbContext _db;

        public SqlMeasurementKeyData(AquaLogDbContext db)
        {
            _db = db;
        }
        public MeasurementKey Add(MeasurementKey newMeasurementKey)
        {
            _db.Add(newMeasurementKey);
            return newMeasurementKey;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public MeasurementKey Delete(int id)
        {
            var measurementKey = GetById(id);
            if(measurementKey != null)
            {
                _db.Remove(measurementKey);
            }
            return measurementKey;
        }

        public IEnumerable<MeasurementKey> GetMeasurementKeysByName(string name)
        {
            var query = from mk in _db.MeasurementKeys
                        where mk.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby mk.Name
                        select mk;
            return query;
        }

        public MeasurementKey GetById(int id)
        {
            return _db.MeasurementKeys.Find(id);
        }

        public MeasurementKey Update(MeasurementKey updatedMeasurementKey)
        {
            var entity = _db.MeasurementKeys.Attach(updatedMeasurementKey);
            entity.State = EntityState.Modified;
            return updatedMeasurementKey;
        }
    }
}