using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using K9.WebApplication.Services;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    public class HomeController : BaseGcController
    {
        private readonly IAuthentication _authentication;
        private readonly IKitchenManagerService _kitchenManagerService;

        public HomeController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles, IAuthentication authentication, IFileSourceHelper fileSourceHelper, IKitchenManagerService kitchenManagerService)
            : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
        {
            _authentication = authentication;
            _kitchenManagerService = kitchenManagerService;
        }

        public ActionResult Index()
        {
            return View(_kitchenManagerService.GetAllergenSheetModel());
        }

        [Route("privacy-policy")]
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public override string GetObjectName()
        {
            return string.Empty;
        }
    }
}
