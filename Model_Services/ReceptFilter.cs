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
    }
}