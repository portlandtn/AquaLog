using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages
{
    public class LogEntry : PageModel
    {
        private readonly ILogger<LogEntry> _logger;

        public LogEntry(ILogger<LogEntry> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
