using Folke.Identity.Server.Services;
using <%= name %>.Data;
using <%= name %>.ViewModels;

namespace <%= name %>.Services
{
    public class RoleService : IRoleService<Role, RoleViewModel>
    {
        public RoleViewModel MapToRoleView(Role role)
        {
            return new RoleViewModel
            {
                Name = role.Name,
                Id = role.Id
            };
        }

        public Role CreateNewRole(string name)
        {
            return new Role
            {
                Name = name
            };
        }
    }
}
