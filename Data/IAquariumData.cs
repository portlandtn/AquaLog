using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IAquariumData
    {
        IEnumerable<Aquarium> GetAquariumsByName(string name);
        Aquarium GetById(int id);
        Aquarium Update(Aquarium updatedAquarium);
        Aquarium Add(Aquarium newAquarium);
        Aquarium Delete(int id);
        int Commit();
    }
}