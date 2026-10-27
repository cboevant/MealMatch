using MealMatch.Model_Services;
using MealMatch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealMatch.Pages
{
    public class ReceptDetailsModel : PageModel
    {
        private readonly ReceptService _receptService;

        public ReceptDetailsModel(ReceptService receptService)
        {
            _receptService = receptService;
        }

        public Recept? Recept { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? PlanDatum { get; set; }

        public void OnGet(int id)
        {
            Recept = _receptService.HaalReceptOp(id);
        }
    }
}