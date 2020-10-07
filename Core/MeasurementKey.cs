using System;

namespace AquaLog.Core
{
    public class MeasurementKey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ApplicableToFreshwater { get; set; }
        public bool ApplicableToSaltwater { get; set; }
        public double HighRange { get; set; }
        public double LowRange { get; set; }
        public double IdealLevel { get; set; }
    }
}