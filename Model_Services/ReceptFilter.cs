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

        public List<Recept> ZoekOpNaam(List<Recept> recepten, string? zoektekst)
        {
            // Geen zoektekst: alle recepten teruggeven
            if (string.IsNullOrWhiteSpace(zoektekst))
            {
                return recepten;
            }

            List<Recept> resultaat = new List<Recept>();

            foreach (Recept recept in recepten)
            {
                if (recept.Naam.Contains(zoektekst.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    resultaat.Add(recept);
                }
            }

            return resultaat;
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