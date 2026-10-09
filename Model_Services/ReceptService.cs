using MealMatch.Data;
using MealMatch.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMatch.Model_Services
{
    public class ReceptService
    {
        private readonly MealMatchDbContext _context;

        public ReceptService(MealMatchDbContext context)
        {
            _context = context;
        }

        public void VoegReceptToe(Recept recept)
        {
            foreach (ReceptIngredient receptIngredient in recept.ReceptIngredienten)
            {
                string naam = receptIngredient.Ingredient.Naam.Trim();

                // Bestaat dit ingrediënt al in de database?
                Ingredient? bestaandIngredient = _context.Ingredienten
                    .FirstOrDefault(i => i.Naam == naam);

                if (bestaandIngredient != null)
                {
                    // Ja: gebruik het bestaande ingrediënt
                    receptIngredient.Ingredient = bestaandIngredient;
                }
                else
                {
                    // Nee: er wordt een nieuw ingrediënt aangemaakt
                    receptIngredient.Ingredient.Naam = naam;
                }
            }
            _context.Recepten.Add(recept);
            _context.SaveChanges();
        }

        public List<Recept> HaalReceptenOp()
        {
            return _context.Recepten
                .Include(r => r.ReceptIngredienten)
                    .ThenInclude(ri => ri.Ingredient)
                .ToList();
        }
    }
}