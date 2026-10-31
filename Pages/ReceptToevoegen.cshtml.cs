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
        public IActionResult OnGet(int? id)
        {
            // Geen id: een nieuw recept
            if (id == null)
            {
                ReceptIngredienten.Add(new ReceptIngredient());
                return Page();
            }

            // Wel een id: een bestaand recept bewerken
            Recept? bestaand = _receptService.HaalReceptOp(id.Value);

            if (bestaand == null)
            {
                return RedirectToPage("/Recepten");
            }

            Recept = bestaand;
            ReceptIngredienten = bestaand.ReceptIngredienten;

            if (ReceptIngredienten.Count == 0)
            {
                ReceptIngredienten.Add(new ReceptIngredient());
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // Extra controle die niet met een attribuut kan: minimaal één ingrediënt
            if (ReceptIngredienten.Count == 0)
            {
                ModelState.AddModelError("Ingredienten", "Voeg minimaal één ingrediënt toe.");
            }

            // Spaties voor, na en tussen de naam weghalen
            // Spaties voor, na en tussen de naam weghalen
            Recept.Naam = _receptService.MaakNaamSchoon(Recept.Naam);

            // Controle: bestaat er al een recept met deze naam?
            if (_receptService.NaamBestaatAl(Recept.Naam, Recept.Id))
            {
                ModelState.AddModelError("Recept.Naam", "Er bestaat al een recept met deze naam.");
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
            if (Recept.Id == 0)
            {
                _receptService.VoegReceptToe(Recept);
            }
            else
            {
                _receptService.WerkReceptBij(Recept);
            }

            return RedirectToPage("/ReceptDetails", new { id = Recept.Id });
        }
    }
}