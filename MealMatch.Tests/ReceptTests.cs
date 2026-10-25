using System.ComponentModel.DataAnnotations;
using MealMatch.Models;

namespace MealMatch.Tests
{
    public class ReceptTests
    {
        // Hulpmethode: controleert de regels ([Required], [Range]) van een recept
        private bool IsGeldig(Recept recept)
        {
            ValidationContext context = new ValidationContext(recept);
            List<ValidationResult> fouten = new List<ValidationResult>();

            return Validator.TryValidateObject(recept, context, fouten, true);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        [InlineData(20)]
        public void Personen_BinnenBereik_IsGeldig(int personen)
        {
            // Arrange
            Recept recept = new Recept
            {
                Naam = "Pasta",
                BereidingstijdMinuten = 20,
                Bereidingswijze = "Kook de pasta.",
                Personen = personen
            };

            // Act
            bool geldig = IsGeldig(recept);

            // Assert
            Assert.True(geldig);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(21)]
        [InlineData(-1)]
        public void Personen_BuitenBereik_IsOngeldig(int personen)
        {
            // Arrange
            Recept recept = new Recept
            {
                Naam = "Pasta",
                BereidingstijdMinuten = 20,
                Bereidingswijze = "Kook de pasta.",
                Personen = personen
            };

            // Act
            bool geldig = IsGeldig(recept);

            // Assert
            Assert.False(geldig);
        }
    }
}