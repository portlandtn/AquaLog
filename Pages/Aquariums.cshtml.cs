using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages
{
    public class Aquariums : PageModel
    {
        private readonly ILogger<Aquariums> _logger;

        public Aquariums(ILogger<Aquariums> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
