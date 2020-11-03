using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Keys
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

        public async Task<IActionResult> OnGet(int? measurementKeyId)
        {
            if (measurementKeyId.HasValue)
            {
                MeasurementKey = await _measurementKeyData.GetById(measurementKeyId.Value);
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
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MeasurementKey.Id > 0)
            {
                await _measurementKeyData.Update(MeasurementKey);
            }
            else
            {
                await _measurementKeyData.Add(MeasurementKey);
            }
            await _measurementKeyData.Commit();
            TempData["Message"] = "Measurement Key saved!";
            return RedirectToPage("./MeasurementKeyDetails", new { measurementKeyId = MeasurementKey.Id }); // Post-Redirect-Get pattern to avoid refreshing a post
        }

    }
}
