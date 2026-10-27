namespace MealMatch.Models
{
    public class Planning
    {
        public int Id { get; set; }

        // De dag waarop de maaltijd gepland is (alleen de datum is belangrijk, niet de tijd)
        public DateTime Datum { get; set; }

        // Welk recept er op die dag gegeten wordt
        public int ReceptId { get; set; }
        public Recept? Recept { get; set; }
    }
}