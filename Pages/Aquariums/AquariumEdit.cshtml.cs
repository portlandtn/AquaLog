using System.Collections.Generic;
using System.Threading.Tasks;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Aquariums
{
    public class AquariumEdit : PageModel
    {
        private readonly ILogger<AquariumEdit> _logger;
        private readonly IAquariumData _aquariumData;
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Aquarium Aquarium { get; set; }
        public IEnumerable<SelectListItem> AquariumTypes { get; set; }

        public AquariumEdit(ILogger<AquariumEdit> logger, IAquariumData aquariumData, IHtmlHelper helper)
        {
            _logger = logger;
            _aquariumData = aquariumData;
            _helper = helper;
        }

        public async Task<IActionResult> OnGet(int? aquariumId)
        {
            if (aquariumId.HasValue)
            {
                Aquarium = await _aquariumData.GetById(aquariumId.Value);
            }
            else
            {
                Aquarium = new Aquarium();
            }
            if (Aquarium == null)
            {
                RedirectToPage("../Error");
            }

            AquariumTypes = _helper.GetEnumSelectList<AquariumType>();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Aquarium.AquariumId > 0)
            {
                await _aquariumData.Update(Aquarium);
            }
            else
            {
                await _aquariumData.Add(Aquarium);
            }
            await _aquariumData.Commit();
            TempData["Message"] = "Aquarium saved!";
            return RedirectToPage("./AquariumDetails", new { aquariumId = Aquarium.AquariumId }); // Post-Redirect-Get pattern to avoid refreshing a post
        }

    }
}
