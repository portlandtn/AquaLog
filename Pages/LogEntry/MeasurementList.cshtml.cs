using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.LogEntry
{
    public class MeasurementList : PageModel
    {
        private readonly ILogger<MeasurementList> _logger;
        private readonly IMeasurementData _measurementData;
        public IEnumerable<Measurement> Measurements { get; set; }
        public Log Log { get; set; }
        public MeasurementKey MeasurementKey { get; set; }
        public Aquarium Aquarium { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        private readonly IMeasurementKeyData _measurementKeyData;
        private readonly IAquariumData _aquariumData;

        public MeasurementList(ILogger<MeasurementList> logger, IMeasurementData measurementData, IAquariumData aquariumData, IMeasurementKeyData measurementKeyData)
        {
            _aquariumData = aquariumData;
            _measurementKeyData = measurementKeyData;
            _measurementData = measurementData;
            _logger = logger;
        }

        public async Task OnGet(DateTime startDate, DateTime endDate)
        {
            //TODO
            Measurements = await _measurementData.GetMeasurementsForRange(startDate, endDate);
        }
    }
}
