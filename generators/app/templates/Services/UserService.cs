using System.Collections.Generic;
using System.Threading.Tasks;
using Folke.Elm;
using Folke.Identity.Server.Services;
using Folke.Identity.Server.Views;
using <%= name %>.ViewModels;
using <%= name %>.Data;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Folke.Elm.Fluent;

namespace <%= name %>.Services
{
    public class UserService : BaseUserService<Account, AccountViewModel>
    {
        private readonly IFolkeConnection connection;

        public UserService(IFolkeConnection connection, IHttpContextAccessor httpContextAccessor, UserManager<Account> userManager) : base(httpContextAccessor, userManager)
        {
            this.connection = connection;
        }

        public override Task<IList<Account>> Search(UserSearchFilter name, int offset, int limit, string sortColumn)
        {
            return connection.SelectAllFrom<Account>().OrderBy(x => x.UserName).Limit(offset, limit).ToListAsync();
        }

        public override AccountViewModel MapToUserView(Account user)
        {
            if (user == null)
            {
                return new AccountViewModel
                {
                    Logged = false
                };
            }

            return new AccountViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                HasPassword = user.PasswordHash != null,
                Id = user.Id,
                Logged = true
            };
        }

        public override Account CreateNewUser(string userName, string email, bool emailConfirmed)
        {
            return new Account
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = emailConfirmed
            };
        }
    }
}
