using MealMatch.Models;

public class ReceptFilterTests
{
    [Fact]
    public void FilterOpBereidingstijd_GeeftAlleenSnelleRecepten()
    {
        // Arrange
        List<Recept> recepten = new List<Recept>
        {
            new Recept { Naam = "Pasta", Bereidingstijd = 20 },
            new Recept { Naam = "Stoofpot", Bereidingstijd = 120 }
        };
        ReceptFilter filter = new ReceptFilter();

        // Act
        List<Recept> resultaat = filter.FilterOpBereidingstijd(recepten, 30);

        // Assert
        Assert.Single(resultaat);
        Assert.Equal("Pasta", resultaat[0].Naam);
    }
}
