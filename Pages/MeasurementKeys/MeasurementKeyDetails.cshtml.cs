﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.MeasurementKeys
{
    public class MeasurementKeyDetails : PageModel
    {
        private readonly ILogger<MeasurementKeyDetails> _logger;
        private readonly IMeasurementKeyData _measurementKeyData;
        [TempData]
        public string Message { get; set; }

        public MeasurementKey MeasurementKey { get; set; }

        public MeasurementKeyDetails(ILogger<MeasurementKeyDetails> logger, IMeasurementKeyData measurementKeyData)
        {
            _logger = logger;
            _measurementKeyData = measurementKeyData;
        }

        public IActionResult OnGet(int measurementKeyId)
        {
            MeasurementKey = _measurementKeyData.GetById(measurementKeyId);
            if (MeasurementKey == null) 
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
