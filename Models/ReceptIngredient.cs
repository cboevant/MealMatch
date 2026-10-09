using System.ComponentModel.DataAnnotations;

namespace MealMatch.Models
{
    public class ReceptIngredient
    {
        public int Id { get; set; }

        public int ReceptId { get; set; }
        public Recept? Recept { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = new();

        [Required(ErrorMessage = "Vul de hoeveelheid van het ingrediënt in.")]
        public string Hoeveelheid { get; set; } = "";
    }
}