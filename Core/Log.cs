using System;

namespace AquaLog.Core
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AquariumId { get; set; }
        public int MeasurementId { get; set; }
        public int MeasurementLevel { get; set; }
    }
}