namespace MealMatch.Models
{
    public class Ingredient
        {
        public int Id { get; set; }
        public string Naam { get; set; } = "";
        public string Hoeveelheid { get; set; } = "";

        public int ReceptID { get; set; }
        
    }

}
