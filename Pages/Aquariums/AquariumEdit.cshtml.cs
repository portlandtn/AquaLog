using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages
{
    public class AquariumEdit : PageModel
    {
        private readonly ILogger<AquariumEdit> _logger;
        private readonly IAquariumData _aquariumData;

        [BindProperty]
        public Aquarium Aquarium { get; set; }

        public AquariumEdit(ILogger<AquariumEdit> logger, IAquariumData aquariumData)
        {
            _logger = logger;
            _aquariumData = aquariumData;
        }

        public IActionResult OnGet(int aquariumId)
        {   

            Aquarium = _aquariumData.GetById(aquariumId);
            if (Aquarium == null)
            {
                RedirectToPage("../Error");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Aquarium = _aquariumData.Update(Aquarium);
            _aquariumData.Commit();
            return Page();
        }

    }
}
