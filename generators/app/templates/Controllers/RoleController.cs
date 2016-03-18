using Folke.Identity.Server.Controllers;
using Folke.Identity.Server.Services;
using <%= name %>.Data;
using <%= name %>.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;

namespace Galerie.Server.Controllers
{
    [Route("api/role")]
    public class RoleController : BaseRoleController<Role, RoleViewModel, int, Account>
    {
        public RoleController(IRoleService<Role, RoleViewModel> roleService, RoleManager<Role> roleManager, UserManager<Account> userManager) : base(roleService, roleManager, userManager)
        {
        }
    }
}
