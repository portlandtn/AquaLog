using System;
using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IMeasurement
    {
        Measurement GetMeasurementsForRange(DateTime start, DateTime end);
        Measurement Update(Measurement updatedMeasurement);
        Measurement Add(Measurement newMeasurement);
        Measurement Delete(int id);
        int Commit();
        
    }
}