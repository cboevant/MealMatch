using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class ReceptToevoegenModel : PageModel
    {
        private readonly ReceptService _receptService;
        private readonly FotoService _fotoService;

        // ASP.NET geeft de ReceptService automatisch mee (zie Program.cs)
        public ReceptToevoegenModel(ReceptService receptService, FotoService fotoService)
        {
            _receptService = receptService;
            _fotoService = fotoService;
        }

        [BindProperty]
        public Recept Recept { get; set; } = new Recept();

        [BindProperty]
        public List<ReceptIngredient> ReceptIngredienten { get; set; } = new();
        [BindProperty]
        public IFormFile? Foto { get; set; }
        public void OnGet()
        {
            // Begin met één lege ingrediëntrij
            ReceptIngredienten.Add(new ReceptIngredient());
        }

        public IActionResult OnPost()
        {
            // Extra controle die niet met een attribuut kan: minimaal één ingrediënt
            if (ReceptIngredienten.Count == 0)
            {
                ModelState.AddModelError("Ingredienten", "Voeg minimaal één ingrediënt toe.");
            }
            if (Foto != null)
            {
                string extensie = Path.GetExtension(Foto.FileName).ToLower();
                List<string> toegestaan = new List<string> { ".jpg", ".jpeg", ".png" };

                if (!toegestaan.Contains(extensie))
                {
                    ModelState.AddModelError("Foto", "Kies een foto van het type .jpg, .jpeg of .png.");
                }

                if (Foto.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("Foto", "De foto mag niet groter zijn dan 5 MB.");
                }
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Foto != null)
            {
                Recept.FotoPad = _fotoService.SlaFotoOp(Foto);
            }

            // De lijst met ingrediënten koppelen aan het recept
            Recept.ReceptIngredienten = ReceptIngredienten;

            // Opslaan in SQL Server
            _receptService.VoegReceptToe(Recept);

            return RedirectToPage("/Recepten");
        }
    }
}