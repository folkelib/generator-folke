using Folke.Identity.Server.Controllers;
using Folke.Identity.Server.Services;
using <%= name %>.Data;
using <%= name %>.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace <%= name %>.Controllers
{
    [Route("api/account")]
    public class AccountController : BaseUserController<Account, AccountViewModel, int>
    {
         public AccountController(IUserService<Account, AccountViewModel> userService, UserManager<Account> userManager, SignInManager<Account> signInManager, IUserEmailService<Account> emailService) : base(userService, userManager, signInManager, emailService)
        {
        }
    }
}
