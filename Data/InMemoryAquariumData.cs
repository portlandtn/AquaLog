using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;

namespace AquaLog.Data
{
    public class InMemoryAquariumData : IAquariumData
    {
        List<Aquarium> aquariums;

        public InMemoryAquariumData()
        {
            aquariums = new List<Aquarium>()
            {
                new Aquarium {Id = 1, Name = "20 Gallon Fresh", Capacity = 20, Freshwater = true, Description = "20 Gallon tank against the wall with the skull" },
                new Aquarium {Id = 2, Name = "Big Saltwater", Capacity = 55, Freshwater = false, Description = "55 Gallon tank with the trigger shrimp" }
            };
        }
        public IEnumerable<Aquarium> GetAquariumsByName(string name)
        {
            return from a in aquariums
                where string.IsNullOrEmpty(name) || a.Name.Contains(name)
                orderby a.Name
                select a;
        }

        public Aquarium GetById(int id)
        {
            return aquariums.SingleOrDefault(r => r.Id == id);
        }
    }
}