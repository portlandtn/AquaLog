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
    public class AquariumDelete : PageModel
    {
        private readonly IAquariumData _aquariumData;
        public Aquarium Aquarium { get; set; }

        public AquariumDelete(IAquariumData aquariumData)
        {
            _aquariumData = aquariumData;
        }
        public IActionResult OnGet(int aquariumId)
        {
            Aquarium = _aquariumData.GetById(aquariumId);
            if(Aquarium == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        public IActionResult OnPost(int aquariumId)
        {
            var aquarium = _aquariumData.Delete(aquariumId);
            _aquariumData.Commit();

            if(aquarium == null)
            {
                return RedirectToPage("./Error");
            }
            TempData["Message"] = $"{aquarium.Name} deleted.";
            return RedirectToPage("./AquariumList");
        }
    }
}

