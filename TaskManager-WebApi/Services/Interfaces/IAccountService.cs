namespace TaskManager.WebApi.Services
{
    using System.Threading.Tasks;
    using TaskManager.Models;

    public interface IAccountService
    {
        Task<object> Login(object loginBindingModel);

        Task<object> Register(object registrationBindingModel);

        ApplicationUser GetUser(string userId);

        string GetUserFullname(string userId);
    }
}
