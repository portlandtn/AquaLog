using System.Threading.Tasks;
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
        public async Task<IActionResult> OnGet(int measurementKeyId)
        {
            MeasurementKey = await _measurementKeyData.GetById(measurementKeyId);
            if(MeasurementKey == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int measurementKeyId)
        {
            var measurementKey = await _measurementKeyData.Delete(measurementKeyId);
            await _measurementKeyData.Commit();

            if(measurementKey == null)
            {
                return RedirectToPage("./Error");
            }
            TempData["Message"] = $"{measurementKey.Name} deleted.";
            return RedirectToPage("./MeasurementKeyList");
        }
    }
}

