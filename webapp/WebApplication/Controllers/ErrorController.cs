using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using NLog;
using System.Web.Mvc;

namespace K9.WebApplication.Controllers
{
    public class ErrorController : BaseGcController
	{
	    private readonly ILogger _logger;

	    public ErrorController(ILogger logger, IDataSetsHelper dataSetsHelper, IRoles roles, IAuthentication authentication, IFileSourceHelper fileSourceHelper)
	        : base(logger, dataSetsHelper, roles, authentication, fileSourceHelper)
	    {
	        _logger = logger;
	    }

        public ActionResult Index(string errorMessage = "")
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _logger.Error(errorMessage);
            }
        	return View("FriendlyError");
		}

		public ActionResult NotFound()
		{
			return View("NotFound");
		}

		public ActionResult Unauthorized()
		{
			return View("Unauthorized");
		}

	    public override string GetObjectName()
	    {
	        return string.Empty;
	    }
    }
}
