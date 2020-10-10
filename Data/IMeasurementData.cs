using System;
using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IMeasurementData
    {
        IEnumerable<Measurement> GetMeasurementsForRange(DateTime startDate, DateTime endDate);
        Measurement GetById(int id);
        Measurement Update(Measurement updatedMeasurement);
        Measurement Add(Measurement newMeasurement);
        Measurement Delete(int id);
        int Commit();
        
    }
}