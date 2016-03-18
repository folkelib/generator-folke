using Folke.Identity.Server.Controllers;
using Folke.Identity.Server.Services;
using <%= name %>.Data;
using <%= name %>.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace <%= name %>.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : BaseAuthenticationController<Account, int, AccountViewModel>
    {
        public AuthenticationController(IUserService<Account, AccountViewModel> userService, UserManager<Account> userManager, SignInManager<Account> signInManager, IUserEmailService<Account> emailService, ILogger<BaseAuthenticationController<Account, int, AccountViewModel>> logger) : base(userService, userManager, signInManager, emailService, logger)
        {
        }
    }
}
