namespace MealMatch.Model_Services
{
    public class FotoService
    {
        private readonly IWebHostEnvironment _omgeving;

        public FotoService(IWebHostEnvironment omgeving)
        {
            _omgeving = omgeving;
        }

        public string SlaFotoOp(IFormFile foto)
        {
            // Een unieke naam, zodat twee foto's met dezelfde naam elkaar niet overschrijven
            string extensie = Path.GetExtension(foto.FileName).ToLower();
            string bestandsnaam = Guid.NewGuid().ToString() + extensie;

            // De map wwwroot/uploads (wordt aangemaakt als hij nog niet bestaat)
            string map = Path.Combine(_omgeving.WebRootPath, "uploads");
            Directory.CreateDirectory(map);

            // Het bestand opslaan
            string volledigPad = Path.Combine(map, bestandsnaam);
            using (FileStream stream = new FileStream(volledigPad, FileMode.Create))
            {
                foto.CopyTo(stream);
            }

            // Dit pad komt in de database
            return "/uploads/" + bestandsnaam;
        }
    }
}