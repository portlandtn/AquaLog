using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IAquariumData
    {
        Task<IEnumerable<Aquarium>> GetAquariumsByName(string name);
        Task<Aquarium> GetById(int id);
        Task<Aquarium> Update(Aquarium updatedAquarium);
        Task<Aquarium> Add(Aquarium newAquarium);
        Task<Aquarium> Delete(int id);
        Task<int> Commit();
    }
}