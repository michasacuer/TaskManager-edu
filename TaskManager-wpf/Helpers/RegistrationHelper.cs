namespace TaskManager.WPF.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class RegistrationHelper
    {
        public void ExternalRegistration(RegistrationViewModel vm)
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
        }
    }
}
