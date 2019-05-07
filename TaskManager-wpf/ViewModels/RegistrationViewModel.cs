﻿namespace TaskManager.WPF.ViewModels
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
        public RegistrationViewModel(FakeData context, HttpDataService httpDataService)
        {
            this.TextBoxesInitialize();
            this.context = context;
            this.HttpDataService = httpDataService;
        }

        public bool IsFormEnabled { get; set; } = true;

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

                RegistrationForm.SetRole(accountForm, this.ManagerChecked, this.DeveloperChecked, this.ViewerChecked);
                RegistrationForm.IsValid(accountForm, this.context);

                string succes = await this.HttpDataService.Register(accountForm);

                Show.SuccesBox(succes);
                this.TryClose();
            }
            catch (FormValidationException exception)
            {
                this.IsFormEnabled = true;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);

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

        private HttpDataService HttpDataService { get; set; }
    }
}
