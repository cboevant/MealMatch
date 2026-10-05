using MealMatch.Models;
using Microsoft.EntityFrameworkCore;///verdieping

namespace MealMatch.Data
{
    public class MealMatchDbContext : DbContext
    {
        public MealMatchDbContext(DbContextOptions<MealMatchDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recept> Recepten { get; set; }
        public DbSet<Ingredient> Ingredienten { get; set; }
    }
}