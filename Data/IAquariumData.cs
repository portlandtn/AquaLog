using System.Collections.Generic;
using AquaLog.Core;

namespace AquaLog.Data
{
    public interface IAquariumData
    {
         IEnumerable<Aquarium> GetAquariumsByName(string name);

    }
}