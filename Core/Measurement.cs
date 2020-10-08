using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class Measurement
    {
        public int LogId { get; set; }
        public int MeasurementKeyId { get; set; }
        public int AquariumId { get; set; }
        [Required, Range(1, 200)]
        public double Meaurement { get; set; }
    }
}