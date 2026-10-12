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
        public Recept? HaalReceptOp(int id)
        {
            return _context.Recepten
                .Include(r => r.ReceptIngredienten)
                    .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefault(r => r.Id == id);
        }

        public void VoegReceptToe(Recept recept)
        {
            KoppelBestaandeIngredienten(recept.ReceptIngredienten);
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
        public List<Recept> FilterOpBereidingstijd(int minuten)
        {
            return _context.Recepten
                .Where(r => r.BereidingstijdMinuten == minuten)
                .Include(r => r.ReceptIngredienten)
                    .ThenInclude(ri => ri.Ingredient)
                .ToList();
        }

        public List<int> HaalBereidingstijdenOp()
        {
            return _context.Recepten
                .Select(r => r.BereidingstijdMinuten)
                .Distinct()
                .OrderBy(tijd => tijd)
                .ToList();
        }
        public void VerwijderRecept(int id)
        {
            Recept? recept = _context.Recepten.Find(id);

            if (recept != null)
            {
                _context.Recepten.Remove(recept);
                _context.SaveChanges();
            }
        }
        public void WerkReceptBij(Recept gewijzigd)
        {
            Recept? bestaand = _context.Recepten
                .Include(r => r.ReceptIngredienten)
                .FirstOrDefault(r => r.Id == gewijzigd.Id);

            if (bestaand == null)
            {
                return;
            }

            // De gewone velden overnemen
            bestaand.Naam = gewijzigd.Naam;
            bestaand.BereidingstijdMinuten = gewijzigd.BereidingstijdMinuten;
            bestaand.Personen = gewijzigd.Personen;
            bestaand.Bereidingswijze = gewijzigd.Bereidingswijze;
            bestaand.Opmerking = gewijzigd.Opmerking;
            bestaand.FotoPad = gewijzigd.FotoPad;

            // Oude ingrediëntregels weg, nieuwe erin
            _context.ReceptIngredienten.RemoveRange(bestaand.ReceptIngredienten);
            KoppelBestaandeIngredienten(gewijzigd.ReceptIngredienten);

            foreach (ReceptIngredient receptIngredient in gewijzigd.ReceptIngredienten)
            {
                bestaand.ReceptIngredienten.Add(receptIngredient);
            }

            _context.SaveChanges();
        }
        private void KoppelBestaandeIngredienten(List<ReceptIngredient> receptIngredienten)
        {
            foreach (ReceptIngredient receptIngredient in receptIngredienten)
            {
                string naam = receptIngredient.Ingredient.Naam.Trim();

                Ingredient? bestaandIngredient = _context.Ingredienten
                    .FirstOrDefault(i => i.Naam == naam);

                if (bestaandIngredient != null)
                {
                    receptIngredient.Ingredient = bestaandIngredient;
                }
                else
                {
                    receptIngredient.Ingredient.Naam = naam;
                }
            }
        }
    }
}