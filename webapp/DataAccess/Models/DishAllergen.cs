using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Name(ResourceType = typeof(K9.Globalisation.Dictionary), ListName = Globalisation.Strings.Names.DishAllergens, PluralName = Globalisation.Strings.Names.DishAllergens, Name = Globalisation.Strings.Names.DishAllergen)]
    public class DishAllergen : ObjectBase
    {

        [Required]
        [ForeignKey("Dish")]
        public int DishId { get; set; }
		
        [Required]
        [ForeignKey("Allergen")]
        public int AllergenId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Allergen Allergen { get; set; }

        [LinkedColumn(LinkedTableName = "Dish", LinkedColumnName = "FullName")]
        public string DishName { get; set; }

        [LinkedColumn(LinkedTableName = "Allergen", LinkedColumnName = "FullName")]
        public string AllergenName { get; set; }
    }
}
