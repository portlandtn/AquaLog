using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Logs
{
    public class LogEdit : PageModel
    {
        private readonly ILogger<LogEdit> _logger;
        private readonly ILogData _logData;

        [BindProperty]
        public Log Log { get; set; }

        public LogEdit(ILogger<LogEdit> logger, ILogData logData)
        {
            _logger = logger;
            _logData = logData;
        }

        public IActionResult OnGet(int? logId)
        {
            if (logId.HasValue)
            {
                Log = _logData.GetById(logId.Value);
            }
            else
            {
                Log = new Log();
            }
            if (Log == null)
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

            if (Log.Id > 0)
            {
                _logData.Update(Log);
            }
            else
            {
                _logData.Add(Log);
            }
            _logData.Commit();
            TempData["Message"] = "Log saved!";
            return RedirectToPage("./LogDetails", new { logId = Log.Id }); // Post-Redirect-Get pattern to avoid refreshing a post
        }

    }
}
