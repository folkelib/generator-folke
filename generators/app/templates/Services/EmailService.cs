using System.Threading.Tasks;
using Folke.Identity.Server.Services;
using <%= name %>.Data;

namespace <%= name %>.Services
{
    public class EmailService : IUserEmailService<Account>
    {
        public Task SendEmailConfirmationEmail(Account user)
        {
            return Task.FromResult(0);
        }

        public Task SendPasswordResetEmail(Account user)
        {
            return Task.FromResult(0);
        }
    }
}
