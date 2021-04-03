using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int AquariumId { get; set; }
        public string Notes { get; set; }
        public virtual Aquarium Aquarium { get; set; }
        public virtual ICollection<Measurement> Measurement { get; set; }
    }
}