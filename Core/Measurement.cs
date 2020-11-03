using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Measurement
    {
        public int Id { get; set; }
        [Required]
        public int LogId { get; set; }
        [Required]
        public int MeasurementKeyId { get; set; }
        [Required]
        public int AquariumId { get; set; }
        [Required, Range(1, 200)]
        public double Value { get; set; }
        public virtual IEnumerable<MeasurementKey> MeasurementKeys { get; set; }
        public virtual Log Log { get; set; }
        public virtual Aquarium Aquarium { get; set; }
    }
}