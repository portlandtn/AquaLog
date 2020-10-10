using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AquaLog.Pages.Keys
{
    public class MeasurementKeyDelete : PageModel
    {
        private readonly IMeasurementKeyData _measurementKeyData;
        public MeasurementKey MeasurementKey { get; set; }

        public MeasurementKeyDelete(IMeasurementKeyData measurementKeyData)
        {
            _measurementKeyData = measurementKeyData;
        }
        public IActionResult OnGet(int measurementKeyId)
        {
            MeasurementKey = _measurementKeyData.GetById(measurementKeyId);
            if(MeasurementKey == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        public IActionResult OnPost(int measurementKeyId)
        {
            var measurementKey = _measurementKeyData.Delete(measurementKeyId);
            _measurementKeyData.Commit();

            if(measurementKey == null)
            {
                return RedirectToPage("./Error");
            }
            TempData["Message"] = $"{measurementKey.Name} deleted.";
            return RedirectToPage("./MeasurementKeyList");
        }
    }
}

