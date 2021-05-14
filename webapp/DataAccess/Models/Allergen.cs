using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Models;
using K9.Base.Globalisation;
using K9.SharedLibrary.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace K9.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Name(ResourceType = typeof(K9.Globalisation.Dictionary), ListName = Globalisation.Strings.Names.Allergens, PluralName = Globalisation.Strings.Names.Allergens, Name = Globalisation.Strings.Names.Allergen)]
    public class Allergen : ObjectBase
    {

        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.NameLabel)]
        [StringLength(128)]
        public string FullName { get; set; }
    }
}
