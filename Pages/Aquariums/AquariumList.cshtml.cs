using System.Collections.Generic;
using AquaLog.Core;
using AquaLog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AquaLog.Pages.Aquariums
{
    public class AquariumList : PageModel
    {
        private readonly ILogger<AquariumList> _logger;
        private readonly IAquariumData _aquariumData;
        public IEnumerable<Aquarium> Aquariums { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public AquariumList(ILogger<AquariumList> logger, IAquariumData aquariumData)
        {
            _aquariumData = aquariumData;
            _logger = logger;
        }

        public void OnGet()
        {
            Aquariums = _aquariumData.GetAquariumsByName(SearchTerm);
        }
    }
}
