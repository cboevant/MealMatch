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

        public void OnGet()
        {
            Recepten = _receptService.HaalReceptenOp();
        }
        public IActionResult OnPostVerwijder(int id)
        {
            _receptService.VerwijderRecept(id);
            return RedirectToPage();
        }
    }
}