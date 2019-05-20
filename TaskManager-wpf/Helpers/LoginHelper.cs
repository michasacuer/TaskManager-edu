namespace TaskManager.WPF.Helpers
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class LoginHelper
    {
        public async Task<ValidationResult> ExternalLogin(LoginViewModel vm)
        {
            var loginForm = new LoginBindingModel
            {
                UserName = vm.LoginTextBox,
                Password = vm.PasswordTextBox
            };

            var validationResult = LoginForm.IsValid(loginForm);

            if (validationResult.IsValid)
            {
                var httpDataService = new HttpDataService();
                var user = await httpDataService.Login(loginForm);
                vm.LoggedUser.LoginUserToApp(user);
            }

            return validationResult;
        }
    }
}
