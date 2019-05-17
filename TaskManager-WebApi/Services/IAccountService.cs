namespace TaskManager.WebApi.Services
{
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task<object> Login(object loginBindingModel);

        Task<object> Register(object registrationBindingModel);
    }
}
