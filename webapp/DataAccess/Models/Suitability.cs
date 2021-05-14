using K9.Base.DataAccessLayer.Attributes;
using K9.Base.DataAccessLayer.Models;
using K9.Base.Globalisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace K9.DataAccessLayer.Models
{
    [AutoGenerateName]
    [Name(ResourceType = typeof(K9.Globalisation.Dictionary), ListName = Globalisation.Strings.Names.Suitabilities, PluralName = Globalisation.Strings.Names.Suitabilities, Name = Globalisation.Strings.Names.Suitability)]
    public class Suitability : ObjectBase
    {

        [Index(IsUnique = true)]
        [Required(ErrorMessageResourceType = typeof(Dictionary), ErrorMessageResourceName = Strings.ErrorMessages.FieldIsRequired)]
        [Display(ResourceType = typeof(Dictionary), Name = Strings.Labels.NameLabel)]
        [StringLength(128)]
        public string FullName { get; set; }
    }
}
