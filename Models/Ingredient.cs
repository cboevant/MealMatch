using System.ComponentModel.DataAnnotations;

namespace MealMatch.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vul de naam van het ingrediënt in.")]
        public string Naam { get; set; } = "";
        [Required(ErrorMessage = "Vul de hoeveelheid van het ingrediënt in.")]
        public string Hoeveelheid { get; set; } = "";
        public int ReceptID { get; set; }
        public Ingredient()
        {

        }
        
    }

}
