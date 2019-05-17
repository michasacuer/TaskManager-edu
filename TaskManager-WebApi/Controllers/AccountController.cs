namespace TaskManager_WebApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models.BingindModels;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginBindingModel model)
        {
            var result = await this.accountService.Login(model);

            if (result is bool)
            {
                return this.Unauthorized();
            }
            else
            {
                return this.Ok(result);
            }
        }

        [HttpPost("Register")]
        public async Task<object> Register([FromBody] RegistrationBindingModel model)
        {
            var result = await this.accountService.Register(model);

            if ((bool)result)
            {
                return this.Ok();
            }
            else
            {
                return this.Conflict();
            }
        }
    }
}