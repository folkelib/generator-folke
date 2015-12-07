using System;
using System.Collections.Generic;
using Folke.Identity.Server.Services;
using <%= name %>.ViewModels;
using <%= name %>.Data;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.OptionsModel;

namespace <%= name %>.Services
{
    public class UserService : AbstractUserService<Account, AccountViewModel>
    {
        public UserService(IUserStore<Account> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<Account> passwordHasher, IEnumerable<IUserValidator<Account>> userValidators, IEnumerable<IPasswordValidator<Account>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Account>> logger, IHttpContextAccessor contextAccessor) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, contextAccessor)
        {
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
