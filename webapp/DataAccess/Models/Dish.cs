using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Models;
using K9.Base.Globalisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Name(ResourceType = typeof(K9.Globalisation.Dictionary), ListName = Globalisation.Strings.Names.Dishes, PluralName = Globalisation.Strings.Names.Dishes, Name = Globalisation.Strings.Names.Dish)]
    public class Dish : ObjectBase
    {
        public enum EDishType
        {
            Unspecified,
            Starter,
            Main,
            Dessert
        }

        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.NameLabel)]
        [StringLength(128)]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Globalisation.Dictionary), Name =  K9.Globalisation.Strings.Labels.DishTypeLabel)]
        public EDishType DishType { get; set; }
    }
}
