using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Aquarium Aquarium { get; set; }
        public IEnumerable<Aquarium> Aquariums { get; set;}

        public MeasurementEdit(ILogger<MeasurementEdit> logger, IMeasurementData measurementData, IMeasurementKeyData measurementKeyData, IAquariumData aquariumData)
        {
            _logger = logger;
            _measurementData = measurementData;
            _measurementKeyData = measurementKeyData;
            _aquariumData = aquariumData;
        }

        public async Task<IActionResult> OnGet(int? measurementId)
        {
            Aquariums = await _aquariumData.GetAquariumsByName(null);

            if (measurementId.HasValue)
            {
                Measurement = await _measurementData.GetById(measurementId);
                //MeasurementKeys = await _measurementKeyData.GetMeasurementKeysByApplicableType(AquariumType.FRESHWATER);
            }
            else
            {
                Measurement = new Measurement();
                MeasurementKeys = await _measurementKeyData.GetMeasurementKeysByName(null);
            }
            if (Measurement == null)
            {
                RedirectToPage("../Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Measurement.LogId > 0)
            {
                await _measurementData.Update(Measurement);
            }
            else
            {
                await _measurementData.Add(Measurement);
            }
            await _measurementData.Commit();
            TempData["Message"] = "Log Entry saved!";
            return RedirectToPage("./MeasurementDetails", Measurement.MeasurementId); // Post-Redirect-Get pattern to avoid refreshing a post
        }
    }
}
