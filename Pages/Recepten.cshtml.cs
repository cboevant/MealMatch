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
        public int? GekozenPersonen { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Zoektekst { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Sortering { get; set; } = "az";

        [BindProperty(SupportsGet = true)]
        public string Weergave { get; set; } = "kaartjes";
        [BindProperty(SupportsGet = true)]
        public DateTime? PlanDatum { get; set; }
        public List<int> Bereidingstijden { get; set; } = new();
        public List<int> AantallenPersonen { get; set; } = new();

        public void OnGet()
        {
            Bereidingstijden = _receptService.HaalBereidingstijdenOp();
            AantallenPersonen = _receptService.HaalAantallenPersonenOp();
            Recepten = _receptService.HaalReceptenOp();

            ReceptFilter filter = new ReceptFilter();

            if (GekozenTijd != null)
            {
                Recepten = filter.FilterOpBereidingstijd(Recepten, GekozenTijd.Value);
            }

            if (GekozenPersonen != null)
            {
                Recepten = filter.FilterOpPersonen(Recepten, GekozenPersonen.Value);
            }

            Recepten = filter.ZoekOpNaamOfIngredient(Recepten, Zoektekst);

            Recepten = filter.SorteerOpNaam(Recepten, Sortering);
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