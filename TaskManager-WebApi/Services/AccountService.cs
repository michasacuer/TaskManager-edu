namespace TaskManager.WebApi.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using TaskManager.Models;

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
            throw new NotImplementedException();
        }

        public async Task<object> Register(object registrationBindingModel)
        {
            throw new NotImplementedException();
        }
    }
}
