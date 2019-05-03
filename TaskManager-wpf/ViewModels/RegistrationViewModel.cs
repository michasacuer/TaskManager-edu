namespace TaskManager.WPF.ViewModels
{
    using System;
    using Caliburn.Micro;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;

    internal class RegistrationViewModel : Screen
    {
        public RegistrationViewModel(FakeData context, HttpDataService httpDataService)
        {
            this.TextBoxesInitialize();
            this.context = context;
            this.httpDataService = httpDataService;
        }

        public string LoginTextBox { get; set; }

        public string FirstNameTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public string LastNameTextBox { get; set; }

        public string EmailTextBox { get; set; }

        public Role Role { get; set; }

        public bool ManagerChecked { get; set; }

        public bool DeveloperChecked { get; set; }

        public bool ViewerChecked { get; set; }

        public async void AcceptButton()
        {
            try
            {
                RegistrationBindingModel accountForm = new RegistrationBindingModel
                {
                    UserName = this.LoginTextBox,
                    Password = this.PasswordTextBox,
                    FirstName = this.FirstNameTextBox,
                    LastName = this.LastNameTextBox,
                    Email = this.EmailTextBox,
                    Role = this.Role
                };

                RegistrationForm.SetJob(accountForm, this.ManagerChecked, this.DeveloperChecked, this.ViewerChecked);
                RegistrationForm.IsValid(accountForm, this.context);

                string succes = await this.httpDataService.Register(accountForm);

                Show.SuccesBox(succes);
                this.TryClose();
            }
            catch (ArgumentException exception)
            {
                Show.ErrorBox(exception.Message);
            }
        }

        public void CancelButton() => this.TryClose();

        private void TextBoxesInitialize()
        {
            this.LoginTextBox = "Wpisz swój Login";
            this.PasswordTextBox = "Hasło";
            this.FirstNameTextBox = "Wpisz swoje Imie";
            this.LastNameTextBox = "Wpisz swoje Nazwisko";
            this.EmailTextBox = "Wpisz swój Email";
        }

        private readonly FakeData context;

        private readonly HttpDataService httpDataService;
    }
}
