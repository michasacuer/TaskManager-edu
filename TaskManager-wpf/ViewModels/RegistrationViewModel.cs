namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;

    internal class RegistrationViewModel : Screen
    {
        public RegistrationViewModel(HttpDataService httpDataService)
        {
            this.HttpDataService = httpDataService;
        }

        public bool IsFormEnabled { get; set; } = true;

        public string LoginTextBox { get; set; } = "Wpisz swój Login";

        public string PasswordTextBox { get; set; } = "Hasło";

        public string FirstNameTextBox { get; set; } = "Wpisz swoje Imie";

        public string LastNameTextBox { get; set; } = "Wpisz swoje Nazwisko";

        public string EmailTextBox { get; set; } = "Wpisz swój Email";

        public Role Role { get; set; }

        public bool ManagerChecked { get; set; }

        public bool DeveloperChecked { get; set; }

        public bool ViewerChecked { get; set; }

        public async void AcceptButton()
        {

            this.IsFormEnabled = false;
            this.NotifyOfPropertyChange(() => this.IsFormEnabled);

            RegistrationBindingModel accountForm = new RegistrationBindingModel
            {
                UserName = this.LoginTextBox,
                Password = this.PasswordTextBox,
                FirstName = this.FirstNameTextBox,
                LastName = this.LastNameTextBox,
                Email = this.EmailTextBox,
                Role = this.Role
            };

            var validationResult = RegistrationForm.IsValid(
                accountForm,
                this.ManagerChecked,
                this.DeveloperChecked,
                this.ViewerChecked);

            if (validationResult.IsValid)
            {
                try
                {
                    await this.HttpDataService.Register(accountForm);

                    Show.SuccesBox(validationResult.Message);
                    this.TryClose();
                }
                catch (RegistrationException exception)
                {
                    Show.ErrorBox(exception.Message);

                    this.IsFormEnabled = true;
                    this.NotifyOfPropertyChange(() => this.IsFormEnabled);
                }
            }
            else
            {
                Show.ErrorBox(validationResult.Message);

                this.IsFormEnabled = true;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);
            }
        }

        public void CancelButton() => this.TryClose();

        private HttpDataService HttpDataService { get; set; }
    }
}
