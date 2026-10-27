using MealMatch.Data;
using MealMatch.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMatch.Model_Services
    //de database
{
    public class PlanningService
    {
        private readonly MealMatchDbContext _context;

        public PlanningService(MealMatchDbContext context)
        {
            _context = context;
        }

        // Haalt de geplande maaltijden op van maandag t/m vrijdag
        public List<Planning> HaalWeekOp(DateTime maandag)
        {
            DateTime vrijdag = maandag.Date.AddDays(4);

            return _context.Planningen
                .Include(p => p.Recept)
                .Where(p => p.Datum >= maandag.Date && p.Datum <= vrijdag)
                .OrderBy(p => p.Datum)
                .ToList();
        }

        // Plant een recept op een dag. Geeft false terug als die dag al bezet is.
        public bool PlanMaaltijd(DateTime datum, int receptId)
        {
            bool dagIsBezet = _context.Planningen.Any(p => p.Datum == datum.Date);

            if (dagIsBezet)
            {
                return false;
            }

            Planning planning = new Planning
            {
                Datum = datum.Date,
                ReceptId = receptId
            };

            _context.Planningen.Add(planning);
            _context.SaveChanges();
            return true;
        }

        // Haalt een maaltijd uit de planning
        public void VerwijderUitPlanning(int id)
        {
            Planning? planning = _context.Planningen.Find(id);

            if (planning != null)
            {
                _context.Planningen.Remove(planning);
                _context.SaveChanges();
            }
        }
    }
}