namespace TaskManager.WPF.Helpers
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class RegistrationHelper
    {
        public async Task<ValidationResult> ExternalRegistration(RegistrationViewModel vm)
        {
            RegistrationBindingModel accountForm = new RegistrationBindingModel
            {
                UserName = vm.LoginTextBox,
                Password = vm.PasswordTextBox,
                FirstName = vm.FirstNameTextBox,
                LastName = vm.LastNameTextBox,
                Email = vm.EmailTextBox,
                Role = vm.Role
            };

            var validationResult = RegistrationForm.IsValid(
                accountForm,
                vm.ManagerChecked,
                vm.DeveloperChecked,
                vm.ViewerChecked);

            if (validationResult.IsValid)
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Register(accountForm);
            }

            return validationResult;
        }
    }
}
