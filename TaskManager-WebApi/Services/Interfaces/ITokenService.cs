namespace TaskManager.WebApi.Services
{
    using System.Threading.Tasks;

    public interface ITokenService
    {
        Task<object> Generate();
    }
}
