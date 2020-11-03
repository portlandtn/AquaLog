using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IMeasurementData
    {
        Task<IEnumerable<Measurement>> GetMeasurementsForRange(DateTime startDate, DateTime endDate);
        Task<Measurement> GetById(int? id);
        Task<Measurement> Update(Measurement updatedMeasurement);
        Task<Measurement> Add(Measurement newMeasurement);
        Task<Measurement> Delete(int id);
        Task<int> Commit();
        
    }
}