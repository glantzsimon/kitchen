using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Models;
using K9.SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Name(ResourceType = typeof(K9.Globalisation.Dictionary), ListName = Globalisation.Strings.Names.DishSuitabilities, PluralName = Globalisation.Strings.Names.DishSuitabilities, Name = Globalisation.Strings.Names.DishSuitability)]
    public class DishSuitability : ObjectBase
    {

        [Required]
        [ForeignKey("Dish")]
        public int DishId { get; set; }
		
        [Required]
        [ForeignKey("Suitability")]
        public int SuitabilityId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Suitability Suitability { get; set; }

        [LinkedColumn(LinkedTableName = "Dish", LinkedColumnName = "FullName")]
        public string DishName { get; set; }

        [LinkedColumn(LinkedTableName = "Suitability", LinkedColumnName = "FullName")]
        public string SuitabilityName { get; set; }
    }
}
