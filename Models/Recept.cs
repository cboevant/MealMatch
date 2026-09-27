namespace MealMatch.Models
{
    public class Recept
    {
        public int Id { get; set; }

        public string Naam { get; set; } = "";

        public int BereidingstijdMinuten { get; set; }

        public int Personen { get; set; }

        public List<Ingredient> Ingredienten { get; set; } = new();

        public string Bereidingswijze { get; set; } = "";

        public string Opmerking { get; set; } = "";
    }
}