using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IMeasurementKeyData
    {
        IEnumerable<MeasurementKey> GetMeasurementKeysByName(string name);
        MeasurementKey GetById(int id);
        MeasurementKey Update(MeasurementKey updatedMeasurementKey);
        MeasurementKey Add(MeasurementKey newMeasurementKey);
        MeasurementKey Delete(int id);
        int Commit();
    }
}