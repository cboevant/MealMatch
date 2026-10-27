namespace MealMatch.Model_Services
//het rekenwerk
{
    public class WeekBerekening
    {
        // Geeft de maandag van de week waarin de datum valt
        public DateTime BerekenMaandag(DateTime datum)
        {
            int dagenNaMaandag;

            if (datum.DayOfWeek == DayOfWeek.Sunday)
            {
                dagenNaMaandag = 6;
            }
            else
            {
                dagenNaMaandag = (int)datum.DayOfWeek - 1;
            }

            return datum.Date.AddDays(-dagenNaMaandag);
        }
    }
}