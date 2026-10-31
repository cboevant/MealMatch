using MealMatch.Models;

namespace MealMatch.Model_Services
{
    public class ReceptFilter
    {
        public List<Recept> FilterOpBereidingstijd(List<Recept> recepten, int minuten)
        {
            List<Recept> resultaat = new List<Recept>();

            foreach (Recept recept in recepten)
            {
                if (recept.BereidingstijdMinuten == minuten)
                {
                    resultaat.Add(recept);
                }
            }
        

            return resultaat;
        }

        public List<Recept> FilterOpPersonen(List<Recept> recepten, int aantal)
        {
            List<Recept> resultaat = new List<Recept>();

            foreach (Recept recept in recepten)
            {
                if (recept.Personen == aantal)
                {
                    resultaat.Add(recept);
                }
            }

            return resultaat;
        }

        public List<Recept> ZoekOpNaamOfIngredient(List<Recept> recepten, string? zoektekst)
        {
            // Geen zoektekst: alle recepten teruggeven
            if (string.IsNullOrWhiteSpace(zoektekst))
            {
                return recepten;
            }

            string tekst = zoektekst.Trim();
            List<Recept> resultaat = new List<Recept>();

            foreach (Recept recept in recepten)
            {
                // Past de naam van het recept of een van de ingrediënten?
                if (recept.Naam.Contains(tekst, StringComparison.OrdinalIgnoreCase) || BevatIngredient(recept, tekst))
                {
                    resultaat.Add(recept);
                }
            }

            return resultaat;
        }

        private bool BevatIngredient(Recept recept, string tekst)
        {
            foreach (ReceptIngredient receptIngredient in recept.ReceptIngredienten)
            {
                if (receptIngredient.Ingredient.Naam.Contains(tekst, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
        public List<Recept> SorteerOpNaam(List<Recept> recepten, string sortering)
        {
            if (sortering == "za")
            {
                return recepten.OrderByDescending(r => r.Naam).ToList();
            }

            return recepten.OrderBy(r => r.Naam).ToList();
        }
    }
}