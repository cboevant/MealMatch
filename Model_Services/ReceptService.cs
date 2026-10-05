using MealMatch.Data;
using MealMatch.Models;
using Microsoft.EntityFrameworkCore;

namespace MealMatch.Model_Services
{
    public class ReceptService
    {
        private readonly MealMatchDbContext _context;

        public ReceptService(MealMatchDbContext context)
        {
            _context = context;
        }

        public void VoegReceptToe(Recept recept)
        {
            _context.Recepten.Add(recept);
            _context.SaveChanges();
        }

        public List<Recept> HaalReceptenOp()
        {
            return _context.Recepten
                .Include(r => r.Ingredienten)
                .ToList();
        }
    }
}