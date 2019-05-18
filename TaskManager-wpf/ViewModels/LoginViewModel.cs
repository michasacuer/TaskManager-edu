namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Exceptions;
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

            this.IsFormEnabled = false;
            this.NotifyOfPropertyChange(() => this.IsFormEnabled);

            var loginForm = new LoginBindingModel
            {
                UserName = this.LoginTextBox,
                Password = this.PasswordTextBox
            };

            var validationResult = LoginForm.IsValid(loginForm);

            if (validationResult.IsValid)
            {
                try
                {
                    var account = await this.HttpDataService.Login(loginForm);
                    this.loggedUser.LoginUserToApp(account);

                    this.TryClose();
                    Show.SuccesBox(validationResult.Message);
                }
                catch (ExternalLoginException exception)
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

        public void RegisterButton() => Show.RegistrationBox(this.context, this.HttpDataService);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;

        private FakeData context;

        private HttpDataService HttpDataService { get; set; }
    }
}
