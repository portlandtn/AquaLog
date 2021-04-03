using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }
        [Required]
        public int LogId { get; set; }
        [Required]
        public int MeasurementKeyId { get; set; }
        [Required, Range(1, 200)]
        public double MeasurementValue { get; set; }
        public virtual Log Log { get; set; }
        public virtual MeasurementKey MeasurementKey { get; set; }

    }
}