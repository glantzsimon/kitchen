using K9.DataAccessLayer.Models;
using System.Collections.Generic;

namespace K9.WebApplication.ViewModels
{
    public class AllergenSheetModel
    {
        public List<Dish> Dishes { get; }
        public List<Allergen> Allergens { get; }
        public List<DishAllergen> DishAllergens { get; }
        public List<DishSuitability> DishSuitabilities { get; }

        public AllergenSheetModel(List<Dish> dishes, List<Allergen> allergens, List<DishAllergen> dishAllergens, List<DishSuitability> dishSuitabilities)
        {
            Dishes = dishes;
            Allergens = allergens;
            DishAllergens = dishAllergens;
            DishSuitabilities = dishSuitabilities;
        }
    }
}