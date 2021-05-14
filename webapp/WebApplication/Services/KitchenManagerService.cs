using K9.DataAccessLayer.Models;
using K9.SharedLibrary.Models;
using K9.WebApplication.ViewModels;

namespace K9.WebApplication.Services
{
    public class KitchenManagerService : IKitchenManagerService
    {
        public IRepository<Allergen> AllergensRepository { get; }
        public IRepository<Dish> DishesRepository { get; }
        public IRepository<DishAllergen> DishAllergenRepository { get; }
        public IRepository<DishSuitability> DishSuitabilityRepository { get; }

        public KitchenManagerService(IRepository<Allergen> allergensRepository, IRepository<Dish> dishesRepository, IRepository<DishAllergen> dishAllergenRepository, IRepository<DishSuitability> dishSuitabilityRepository)
        {
            AllergensRepository = allergensRepository;
            DishesRepository = dishesRepository;
            DishAllergenRepository = dishAllergenRepository;
            DishSuitabilityRepository = dishSuitabilityRepository;
        }

        public AllergenSheetModel GetAllergenSheetModel()
        {
            return new AllergenSheetModel(DishesRepository.List(), AllergensRepository.List(), DishAllergenRepository.List(), DishSuitabilityRepository.List());
        }
    }
}