using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class MeasurementKey
    {
        [Key]
        public int MeasurementKeyId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}