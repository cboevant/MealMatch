using MealMatch.Model_Services;

namespace MealMatch.Tests
{
    public class WeekBerekeningTests
    {
        [Fact]
        public void BerekenMaandag_Woensdag_GeeftMaandagVanDezeWeek()
        {
            // Arrange
            WeekBerekening berekening = new WeekBerekening();
            DateTime woensdag = new DateTime(2026, 10, 28);

            // Act
            DateTime resultaat = berekening.BerekenMaandag(woensdag);

            // Assert
            Assert.Equal(new DateTime(2026, 10, 26), resultaat);
        }

        [Fact]
        public void BerekenMaandag_Zondag_GeeftMaandagVanDezeWeek()
        {   
            // Arrange
            WeekBerekening berekening = new WeekBerekening();
            DateTime zondag = new DateTime(2026, 11, 1);

            // Act
            DateTime resultaat = berekening.BerekenMaandag(zondag);

            // Assert
            Assert.Equal(new DateTime(2026, 10, 26), resultaat);
            
        }

        [Fact]
        public void BerekenMaandag_Maandag_GeeftMaandagVanDezeWeek()
        {
            // Arrange
            WeekBerekening berekening = new WeekBerekening();
            DateTime maandag = new DateTime(2026, 10, 26);

            // Act
            DateTime resultaat = berekening.BerekenMaandag(maandag);

            // Assert
            Assert.Equal(new DateTime(2026, 10, 26), resultaat);
        }
    }
}