using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class ReceptenModel : PageModel
    {
        private readonly ReceptService _receptService;

        public ReceptenModel(ReceptService receptService)
        {
            _receptService = receptService;
        }

        public List<Recept> Recepten { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? GekozenTijd { get; set; }
        public List<int> Bereidingstijden { get; set; } = new();

        public void OnGet()
        {
            Bereidingstijden = _receptService.HaalBereidingstijdenOp();

            if (GekozenTijd == null)
            {
                Recepten = _receptService.HaalReceptenOp();
            }
            else
            {
                Recepten = _receptService.FilterOpBereidingstijd(GekozenTijd.Value);
            }
        }
        public IActionResult OnPostVerwijder(int id)
        {
            _receptService.VerwijderRecept(id);
            return RedirectToPage();
        }
    }
}