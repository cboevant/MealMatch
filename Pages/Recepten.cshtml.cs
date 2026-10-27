using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class ReceptenModel : PageModel
    {
        private readonly ReceptService _receptService;
        private readonly PlanningService _planningService;

        public ReceptenModel(ReceptService receptService, PlanningService planningService)
        {
            _receptService = receptService;
            _planningService = planningService;
        }
        public List<Recept> Recepten { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int? GekozenTijd { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Weergave { get; set; } = "kaartjes";
        [BindProperty(SupportsGet = true)]
        public DateTime? PlanDatum { get; set; }
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
            return RedirectToPage(new { Weergave = Weergave });
        }
        public IActionResult OnPostKies(int id)
        {
            if (PlanDatum != null)
            {
                _planningService.PlanMaaltijd(PlanDatum.Value, id);
            }
            return RedirectToPage("/Index");
        }
    }
}