using System;
using System.ComponentModel.DataAnnotations;

namespace AquaLog.Core
{
    public class MeasurementKey
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public bool ApplicableToFreshwater { get; set; }
        public bool ApplicableToSaltwater { get; set; }
        [Required, Range(1, 200)]
        public double HighRange { get; set; }
        [Required, Range(1, 200)]
        public double LowRange { get; set; }
        [Required, Range(1, 200)]
        public double IdealLevel { get; set; }
    }
}