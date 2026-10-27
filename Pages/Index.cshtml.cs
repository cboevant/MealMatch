using System.Globalization;
using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PlanningService _planningService;

        public IndexModel(PlanningService planningService)
        {
            _planningService = planningService;
        }

        public DateTime Maandag { get; set; }
        public string WeekTekst { get; set; } = "";
        public List<Planning> GeplandeMaaltijden { get; set; } = new();

        public void OnGet()
        {
            WeekBerekening berekening = new WeekBerekening();
            Maandag = berekening.BerekenMaandag(DateTime.Today);

            // Bijvoorbeeld: "26 oktober – 30 oktober"
            CultureInfo nederlands = new CultureInfo("nl-NL");
            DateTime vrijdag = Maandag.AddDays(4);
            WeekTekst = Maandag.ToString("d MMMM", nederlands) + " – " + vrijdag.ToString("d MMMM", nederlands);

            GeplandeMaaltijden = _planningService.HaalWeekOp(Maandag);
        }
    }
}