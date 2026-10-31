using MealMatch.Models;
using MealMatch.Model_Services;

namespace MealMatch.Tests
{
    public class ReceptFilterTests
    {
        [Fact]
        public void FilterOpBereidingstijd_GeeftAlleenSnelleRecepten()
        {
            // Arrange
            List<Recept> recepten = new List<Recept>
        {
            new Recept { Naam = "Pasta", BereidingstijdMinuten = 20 },
            new Recept { Naam = "Stoofpot", BereidingstijdMinuten = 120 }
        };
            ReceptFilter filter = new ReceptFilter();

            // Act
            List<Recept> resultaat = filter.FilterOpBereidingstijd(recepten, 20);

            // Assert
            Assert.Single(resultaat);
            Assert.Equal("Pasta", resultaat[0].Naam);
        }

        [Fact]
        public void ZoekOpNaam_VindtReceptOokMetKleineLetters()
        {
            // Arrange
            List<Recept> recepten = new List<Recept>
    {
        new Recept { Naam = "Courgette bolognese" },
        new Recept { Naam = "Kip tandoori" }
    };
            ReceptFilter filter = new ReceptFilter();

            // Act
            List<Recept> resultaat = filter.ZoekOpNaamOfIngredient(recepten, "BOLO");

            // Assert
            Assert.Single(resultaat);
            Assert.Equal("Courgette bolognese", resultaat[0].Naam);
        }
    }
}
