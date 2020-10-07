using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Aquariums
{
    public class AquariumDetails : PageModel
    {
        private readonly ILogger<AquariumDetails> _logger;
        private readonly IAquariumData _aquariumData;
        [TempData]
        public string Message { get; set; }

        public Aquarium Aquarium { get; set; }

        public AquariumDetails(ILogger<AquariumDetails> logger, IAquariumData aquariumData)
        {
            _logger = logger;
            _aquariumData = aquariumData;
        }

        public IActionResult OnGet(int aquariumId)
        {
            Aquarium = _aquariumData.GetById(aquariumId);
            if (Aquarium == null) 
            {
                return RedirectToPage("../Error");
            }
            return Page();
        }
    }
}
