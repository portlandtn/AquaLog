using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.MeasurementKeys
{
    public class MeasurementKeyEdit : PageModel
    {
        private readonly ILogger<MeasurementKeyEdit> _logger;
        private readonly IMeasurementKeyData _measurementKeyData;

        [BindProperty]
        public MeasurementKey MeasurementKey { get; set; }

        public MeasurementKeyEdit(ILogger<MeasurementKeyEdit> logger, IMeasurementKeyData measurementKeyData)
        {
            _logger = logger;
            _measurementKeyData = measurementKeyData;
        }

        public IActionResult OnGet(int? measurementKeyId)
        {
            if (measurementKeyId.HasValue)
            {
                MeasurementKey = _measurementKeyData.GetById(measurementKeyId.Value);
            }
            else
            {
                MeasurementKey = new MeasurementKey();
            }
            if (MeasurementKey == null)
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

            if (MeasurementKey.Id > 0)
            {
                _measurementKeyData.Update(MeasurementKey);
            }
            else
            {
                _measurementKeyData.Add(MeasurementKey);
            }
            _measurementKeyData.Commit();
            TempData["Message"] = "Measurement Key saved!";
            return RedirectToPage("./MeasurementKeyDetails", new { measurementKeyId = MeasurementKey.Id }); // Post-Redirect-Get pattern to avoid refreshing a post
        }

    }
}
