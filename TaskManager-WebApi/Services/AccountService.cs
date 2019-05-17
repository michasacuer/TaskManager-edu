namespace TaskManager.WebApi.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using TaskManager.Models;
    using TaskManager.Models.BingindModels;
    using TaskManager.Models.ViewModels;

    public class AccountService : IAccountService
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly RoleManager<IdentityRole> roleManager;

        private readonly IConfiguration configuration;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<object> Login(object loginBindingModel)
        {
            var model = (LoginBindingModel)loginBindingModel;

            var result = await this.signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = this.userManager.Users.SingleOrDefault(r => r.UserName == model.UserName);
                var appUserRoles = await this.userManager.GetRolesAsync(appUser);

                var tokenGenerator = new TokenService(model.UserName, appUser, this.configuration, this.userManager);

                var role = appUserRoles.FirstOrDefault();
                var token = await tokenGenerator.Generate();

                return new AccountViewModel
                {
                    Id = appUser.Id,
                    FirstName = appUser.FirstName,
                    LastName = appUser.LastName,
                    Role = role,
                    Bearer = (string)token,
                };
            }

            return false;
        }

        public async Task<object> Register(object registrationBindingModel)
        {
            var model = (RegistrationBindingModel)registrationBindingModel;

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var roleName = model.Role.ToString();
                if (!await this.roleManager.RoleExistsAsync(roleName))
                {
                    var role = new IdentityRole(roleName);
                    await this.roleManager.CreateAsync(role);
                }

                await this.userManager.AddToRoleAsync(user, roleName);

                await this.signInManager.SignInAsync(user, false);
                return true;
            }

            return false;
        }
    }
}
