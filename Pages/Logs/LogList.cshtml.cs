using System.Collections.Generic;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Logs
{
    public class LogList : PageModel
    {
        private readonly ILogger<LogList> _logger;
        private readonly ILogData _logData;
        public IEnumerable<Log> Logs { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public LogList(ILogger<LogList> logger, ILogData logData)
        {
            _logData = logData;
            _logger = logger;
        }

        public void OnGet()
        {
            //TODO
            Logs = _logData.GetLogsByDateRange(new System.DateTime(), new System.DateTime());
        }
    }
}
