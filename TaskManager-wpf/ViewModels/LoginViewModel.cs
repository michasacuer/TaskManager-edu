namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;

    internal class LoginViewModel : Screen
    {
        public LoginViewModel(FakeData context, LoggedUser loggedUser, HttpDataService httpDataService)
        {
            this.context = context;
            this.loggedUser = loggedUser;
            this.HttpDataService = httpDataService;
        }

        public bool IsFormEnabled { get; set; } = true;

        public string LoginTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public async void LoginButton()
        {
            try
            {
                this.IsFormEnabled = false;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);

                //LoginForm.IsValid(this.LoginTextBox, this.PasswordTextBox, this.context); //TODO

                var login = new LoginBindingModel
                {
                    UserName = this.LoginTextBox,
                    Password = this.PasswordTextBox
                };

                await this.HttpDataService.Login(login);

                this.TryClose();
                Show.SuccesBox("Zalogowano pomyślnie!");
                this.loggedUser.LoginUserToApp(this.context.GetUser(this.LoginTextBox));
            }
            catch (ArgumentException exception)
            {
                Show.ErrorBox(exception.Message);

                this.IsFormEnabled = true;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);
            }
        }

        public void RegisterButton() => Show.RegistrationBox(this.context, this.HttpDataService);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;

        private FakeData context;

        private HttpDataService HttpDataService { get; set; }
    }
}
