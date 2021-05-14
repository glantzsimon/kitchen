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
    public class DishesController : BaseController<Dish>
    {
        private readonly ILogger _logger;
        private readonly IMailChimpService _mailChimpService;

        public DishesController(IControllerPackage<Dish> controllerPackage, ILogger logger, IMailChimpService mailChimpService) : base(controllerPackage)
        {
            _logger = logger;
            _mailChimpService = mailChimpService;
        }
        
    }
}
