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
        public async Task<IActionResult> OnGet(int aquariumId)
        {
            Aquarium = await _aquariumData.GetById(aquariumId);
            if(Aquarium == null)
            {
                return RedirectToPage("./Error");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int aquariumId)
        {
            var aquarium = await _aquariumData.Delete(aquariumId);
            await _aquariumData.Commit();

            if(aquarium == null)
            {
                return RedirectToPage("./Error");
            }
            TempData["Message"] = $"{aquarium.Name} deleted.";
            return RedirectToPage("./AquariumList");
        }
    }
}

