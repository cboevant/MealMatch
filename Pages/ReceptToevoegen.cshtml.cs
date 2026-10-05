using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class ReceptToevoegenModel : PageModel
    {
        private readonly ReceptService _receptService;

        // ASP.NET geeft de ReceptService automatisch mee (zie Program.cs)
        public ReceptToevoegenModel(ReceptService receptService)
        {
            _receptService = receptService;
        }

        [BindProperty]
        public Recept Recept { get; set; } = new Recept();

        [BindProperty]
        public List<Ingredient> Ingredienten { get; set; } = new();

        public void OnGet()
        {
            // Begin met één lege ingrediëntrij
            Ingredienten.Add(new Ingredient());
        }

        public IActionResult OnPost()
        {
            // Extra controle die niet met een attribuut kan: minimaal één ingrediënt
            if (Ingredienten.Count == 0)
            {
                ModelState.AddModelError("Ingredienten", "Voeg minimaal één ingrediënt toe.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // De lijst met ingrediënten koppelen aan het recept
            Recept.Ingredienten = Ingredienten;

            // Opslaan in SQL Server
            _receptService.VoegReceptToe(Recept);

            return RedirectToPage("/Recepten");
        }
    }
}