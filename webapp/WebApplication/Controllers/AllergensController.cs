using K9.Base.WebApplication.Controllers;
using K9.Base.WebApplication.Filters;
using K9.Base.WebApplication.UnitsOfWork;
using K9.DataAccessLayer.Models;
using K9.SharedLibrary.Authentication;
using K9.WebApplication.Services;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    [Authorize]
    [RequirePermissions(Role = RoleNames.PowerUsers)]
    public class AllergensController : BaseController<Allergen>
    {
        private readonly ILogger _logger;
        private readonly IMailChimpService _mailChimpService;

        public AllergensController(IControllerPackage<Allergen> controllerPackage, ILogger logger, IMailChimpService mailChimpService) : base(controllerPackage)
        {
            _logger = logger;
            _mailChimpService = mailChimpService;
        }
        
    }
}
