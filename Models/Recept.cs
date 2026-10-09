using System.ComponentModel.DataAnnotations;

namespace MealMatch.Models
{
    public class Recept
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vul de naam van het recept in.")]
        public string Naam { get; set; } = "";
        
        [Range(1, 600, ErrorMessage = "De bereidingstijd moet tussen 1 en 600 minuten zijn.")]
        public int BereidingstijdMinuten { get; set; }

        [Range(1, 20, ErrorMessage = "Het aantal personen moet tussen 1 en 20 zijn.")]
        public int Personen { get; set; }

        public List<ReceptIngredient> ReceptIngredienten { get; set; } = new();

        [Required(ErrorMessage = "Vul de bereidingswijze in.")]
        public string Bereidingswijze { get; set; } = "";

        public string? Opmerking { get; set; } = "";
    }
}