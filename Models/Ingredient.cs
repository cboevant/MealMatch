using System.ComponentModel.DataAnnotations;

namespace MealMatch.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vul de naam van het ingrediënt in.")]
        public string Naam { get; set; } = "";
        public List<ReceptIngredient> ReceptIngredienten { get; set; } = new();
      
    }

}
