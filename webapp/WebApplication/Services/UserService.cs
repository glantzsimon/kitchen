using K9.Base.DataAccessLayer.Models;
using K9.Base.WebApplication.Config;
using K9.DataAccessLayer.Models;
using K9.SharedLibrary.Helpers;
using K9.SharedLibrary.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K9.WebApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _usersRepository;
        private readonly IAuthentication _authentication;
        private readonly IMailer _mailer;
        private readonly IContactService _contactService;
        private readonly WebsiteConfiguration _config;
        private readonly UrlHelper _urlHelper;

        public UserService(IRepository<User> usersRepository, IAuthentication authentication, IMailer mailer, IOptions<WebsiteConfiguration> config, IContactService contactService)
        {
            _usersRepository = usersRepository;
            _authentication = authentication;
            _mailer = mailer;
            _contactService = contactService;
            _config = config.Value;
            _urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
        }

        public void UpdateActiveUserEmailAddressIfFromFacebook(Contact contact)
        {
            if (_authentication.IsAuthenticated)
            {
                var activeUser = _usersRepository.Find(_authentication.CurrentUserId);
                var defaultFacebookAddress = $"{activeUser.FirstName}.{activeUser.LastName}@facebook.com";
                if (activeUser.IsOAuth && activeUser.EmailAddress == defaultFacebookAddress && activeUser.EmailAddress != contact.EmailAddress)
                {
                    if (!_usersRepository.Find(e => e.EmailAddress == contact.EmailAddress).Any())
                    {
                        activeUser.EmailAddress = contact.EmailAddress;
                        _usersRepository.Update(activeUser);
                    }
                }
            }
        }
    }
}