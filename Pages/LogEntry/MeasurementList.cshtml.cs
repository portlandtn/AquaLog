using System;
using System.Collections.Generic;
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

        public MeasurementList(ILogger<MeasurementList> logger, IMeasurementData measurementData)
        {
            _measurementData = measurementData;
            _logger = logger;
        }

        public void OnGet(DateTime startDate, DateTime endDate)
        {
            //TODO
            Measurements = _measurementData.GetMeasurementsForRange(startDate, endDate);
        }
    }
}
