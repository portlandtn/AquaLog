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
        private readonly IAquariumData _aquariumData;

        [BindProperty]
        public Measurement Measurement { get; set; }
        public IEnumerable<MeasurementKey> MeasurementKeys { get; set; }
        public IEnumerable<Aquarium> Aquariums { get; set; }

        public MeasurementEdit(ILogger<MeasurementEdit> logger, IMeasurementData measurementData, IMeasurementKeyData measurementKeyData, IAquariumData aquariumData)
        {
            _logger = logger;
            _measurementData = measurementData;
            _measurementKeyData = measurementKeyData;
            _aquariumData = aquariumData;
        }

        public IActionResult OnGet(int? measurementId)
        {
            Aquariums = _aquariumData.GetAquariumsByName(null);

            if (measurementId.HasValue)
            {
                Measurement = _measurementData.GetById(measurementId);
                MeasurementKeys = _measurementKeyData.GetMeasurementKeysByApplicableType(AquariumType.FRESHWATER);
            }
            else
            {
                Measurement = new Measurement();
                MeasurementKeys = _measurementKeyData.GetMeasurementKeysByName(null);
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
            return RedirectToPage("./MeasurementDetails", Measurement.Id); // Post-Redirect-Get pattern to avoid refreshing a post
        }
    }
}
