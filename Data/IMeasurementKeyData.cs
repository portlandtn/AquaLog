using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IMeasurementKeyData
    {
        Task<IEnumerable<MeasurementKey>> GetMeasurementKeysByName(string name);
        Task<IEnumerable<MeasurementKey>> GetMeasurementKeysByApplicableType(AquariumType aquariumType);
        Task<MeasurementKey> GetById(int id);
        Task<MeasurementKey> Update(MeasurementKey updatedMeasurementKey);
        Task<MeasurementKey> Add(MeasurementKey newMeasurementKey);
        Task<MeasurementKey> Delete(int id);
        Task<int> Commit();
    }
}