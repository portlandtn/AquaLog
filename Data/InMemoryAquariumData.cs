using System.Collections.Generic;
using AquaLog.Core;
using System.Linq;

namespace AquaLog.Data
{
    public class InMemoryAquariumData //: IAquariumData
    {
        List<Aquarium> aquariums;

        public InMemoryAquariumData()
        {
            aquariums = new List<Aquarium>()
            {
                new Aquarium {AquariumId = 1, Name = "20 Gallon Fresh", Capacity = 20, Type = AquariumType.FRESHWATER, Description = "20 Gallon tank against the wall with the skull" },
                new Aquarium {AquariumId = 2, Name = "Big Saltwater", Capacity = 55, Type = AquariumType.SALTWATER, Description = "55 Gallon tank with the trigger shrimp" }
            };
        }

        public Aquarium Add(Aquarium newAquarium)
        {
            aquariums.Add(newAquarium);
            newAquarium.AquariumId = aquariums.Max(a => a.AquariumId + 1);
            return newAquarium;
        }

        public int Commit()
        {
            return 0;
        }

        public Aquarium Delete(int id)
        {
            var aquarium = aquariums.FirstOrDefault(a => a.AquariumId == id);
            if(aquarium != null)
            {
                aquariums.Remove(aquarium);
            }
            return aquarium;
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
            return aquariums.SingleOrDefault(r => r.AquariumId == id);
        }

        public Aquarium Update(Aquarium updatedAquarium)
        {
            var aquarium = aquariums.SingleOrDefault(a => a.AquariumId == updatedAquarium.AquariumId);
            if (aquarium != null)
            {
                aquarium.Name = updatedAquarium.Name;
                aquarium.Capacity = updatedAquarium.Capacity;
                aquarium.Type = updatedAquarium.Type;
                aquarium.Description = updatedAquarium.Description;
            }
            return aquarium;
        }
    }
}