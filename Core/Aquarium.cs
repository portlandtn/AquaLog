using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Aquarium
    {
        [Key]
        public int AquariumId { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, Range(1,500)]
        public int Capacity { get; set; }
        public AquariumType Type { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
    }
}