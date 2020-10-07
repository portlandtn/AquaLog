using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Logs
{
    public class LogDetails : PageModel
    {
        private readonly ILogger<LogDetails> _logger;
        private readonly ILogData _logData;
        [TempData]
        public string Message { get; set; }

        public Log Log { get; set; }

        public LogDetails(ILogger<LogDetails> logger, ILogData logData)
        {
            _logger = logger;
            _logData = logData;
        }

        public IActionResult OnGet(int logId)
        {
            Log = _logData.GetById(logId);
            if (Log == null) 
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
