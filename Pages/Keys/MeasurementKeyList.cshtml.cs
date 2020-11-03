using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Keys
{
    public class MeasurementKeyList : PageModel
    {
        private readonly ILogger<MeasurementKeyList> _logger;
        private readonly IMeasurementKeyData _measurementKeyData;
        public IEnumerable<MeasurementKey> MeasurementKeys { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public MeasurementKeyList(ILogger<MeasurementKeyList> logger, IMeasurementKeyData measurementKeyData)
        {
            _measurementKeyData = measurementKeyData;
            _logger = logger;
        }

        public async Task OnGet()
        {
            MeasurementKeys = await _measurementKeyData.GetMeasurementKeysByName(SearchTerm);
        }
    }
}
