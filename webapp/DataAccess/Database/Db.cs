using K9.DataAccessLayer.Models;
using System.Data.Entity;

namespace K9.DataAccessLayer.Database
{
    public class LocalDb : Base.DataAccessLayer.Database.Db
	{
	    public DbSet<Allergen> Allergens { get; set; }
	    public DbSet<Dish> Dishes { get; set; }
	    public DbSet<Suitability> Suitabilities { get; set; }
	    public DbSet<DishAllergen> DishAllergens { get; set; }
	    public DbSet<DishSuitability> DishSuitabilities { get; set; }
    }
}
