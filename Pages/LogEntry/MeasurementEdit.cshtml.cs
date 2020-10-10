using System.Collections.Generic;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.LogEntry
{
    public class MeasurementEdit : PageModel
    {
        private readonly ILogger<MeasurementEdit> _logger;
        private readonly IMeasurementData _measurementData;
        private readonly IMeasurementKeyData _measurementKeyData;

        [BindProperty]
        public Measurement Measurement { get; set; }
        public IEnumerable<MeasurementKey> MeasurementKeys { get; set; }

        public MeasurementEdit(ILogger<MeasurementEdit> logger, IMeasurementData measurementData, IMeasurementKeyData measurementKeyData)
        {
            _logger = logger;
            _measurementData = measurementData;
            _measurementKeyData = measurementKeyData;
        }

        public IActionResult OnGet(int? measurementId)
        {
            MeasurementKeys = _measurementKeyData.GetMeasurementKeysByName(null); // will get all measurements
            
            if (measurementId.HasValue)
            {
                Measurement = _measurementData.GetById(measurementId.Value);
            }
            else
            {
                Measurement = new Measurement();
            }
            if (Measurement == null)
            {
                RedirectToPage("../Error");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Measurement.LogId > 0)
            {
                _measurementData.Update(Measurement);
            }
            else
            {
                _measurementData.Add(Measurement);
            }
            _measurementData.Commit();
            TempData["Message"] = "Log Entry saved!";
            return RedirectToPage("./MeasurementDetails", new { Measurement.LogId , Measurement.AquariumId, Measurement.MeasurementKeyId }); // Post-Redirect-Get pattern to avoid refreshing a post
        }
    }
}
