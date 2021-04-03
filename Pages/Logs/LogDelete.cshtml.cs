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
    public class LogDelete : PageModel
    {
        private readonly ILogData _logData;
        public Log Log { get; set; }

        public LogDelete(ILogData logData)
        {
            _logData = logData;
        }
        public IActionResult OnGet(int logId)
        {
            Log = _logData.GetById(logId);
            if(Log == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        public IActionResult OnPost(int logId)
        {
            var log = _logData.Delete(logId);
            _logData.Commit();

            if(log == null)
            {
                return RedirectToPage("./Error");
            }
            TempData["Message"] = $"{log.LogId} deleted.";
            return RedirectToPage("./LogList");
        }
    }
}

