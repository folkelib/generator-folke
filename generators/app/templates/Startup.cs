using System.Threading.Tasks;
using Folke.Elm;
using Folke.Elm.Sqlite;
using Folke.Identity.Elm;
using <%= name %>.Data;
using <%= name %>.Services;
using <%= name %>.ViewModels;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Localization;
using Microsoft.AspNet.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace <%= name %>
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json");
            configurationBuilder.AddCommandLine(new string[] { });
            Configuration = configurationBuilder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Account, Role>(options =>
            {
                options.Password = new PasswordOptions
                {
                    RequireDigit = false,
                    RequiredLength = 6,
                    RequireLowercase = false,
                    RequireNonLetterOrDigit = false,
                    RequireUppercase = false
                };
            }).AddDefaultTokenProviders();
            
            services.AddMvc(options =>
            {
                var jsonOutputFormatter = new JsonOutputFormatter
                {
                    SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
                };
                options.OutputFormatters.Insert(0, jsonOutputFormatter);
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("UserList", policy =>
                {
                    policy.RequireRole("Administrator");
                });
                options.AddPolicy("Role", policy =>
                {
                    policy.RequireRole("Administrator");
                });
            });

            services.AddSingleton<IConfiguration>(provider => Configuration) ;
            services.AddSingleton<ConfigurationService>();
            services.AddElm<SqliteDriver>(options =>
            {
                options.ConnectionString = Configuration["Data:IdentityConnection:ConnectionString"];
            });
            services.AddElmIdentity<Account, Role, int>();
            services.AddIdentityServer<Account, int, EmailService, UserService, AccountViewModel>();
            services.AddRoleIdentityServer<Role, RoleService, RoleViewModel>();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IFolkeConnection connection, RoleManager<Role> roleManager, UserManager<Account> userManager)
        {
            app.UseIdentity();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            app.UseRequestLocalization(new RequestCulture("fr-FR"));

            connection.UpdateIdentityUserSchema<int, Account>();
            connection.UpdateIdentityRoleSchema<int, Account>();
            connection.UpdateSchema(typeof (Account).Assembly);
            
            CreateAdministrator(roleManager, userManager).GetAwaiter().GetResult();
        }
        
        private static async Task CreateAdministrator(RoleManager<Role> roleManager, UserManager<Account> userManager)
        {
            var administrateur = await roleManager.FindByNameAsync("Administrator");
            if (administrateur == null)
            {
                await roleManager.CreateAsync(new Role {Name = "Administrator"});
            }

            var users = await userManager.GetUsersInRoleAsync("Administrator");
            if (users.Count == 0)
            {
                var result = await userManager.CreateAsync(new Account { UserName = "Administrator", Email = "admin@example.com" }, 
                        "changethis");
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync("Administrator");
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
        }
    }
}
