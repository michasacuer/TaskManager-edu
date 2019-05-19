namespace TaskManager.WPF.Helpers
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;

    public class LoginHelper
    {
        public async Task<ValidationResult> ExternalLogin(LoggedUser loggedUser, HttpDataService httpDataService, string login, string password)
        {
            var loginForm = new LoginBindingModel
            {
                UserName = login,
                Password = password
            };

            var validationResult = LoginForm.IsValid(loginForm);

            if (validationResult.IsValid)
            {
                var user = await httpDataService.Login(loginForm);
                loggedUser.LoginUserToApp(user);
            }

            return validationResult;
        }
    }
}
