namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    internal class LoginViewModel : Screen
    {
        public LoginViewModel(LoggedUser loggedUser)
        {
            this.loggedUser = loggedUser;
            this.HttpDataService = new HttpDataService();
        }

        public bool IsFormEnabled { get; set; } = true;

        public string LoginTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public async void LoginButton()
        {
            this.IsFormEnabled = false;
            this.NotifyOfPropertyChange(() => this.IsFormEnabled);

            var helper = new LoginHelper();
            try
            {
                var validationResult = await helper.ExternalLogin(this.loggedUser, this.HttpDataService, this.LoginTextBox, this.PasswordTextBox);

                if (validationResult.IsValid)
                {
                    this.TryClose();
                    Show.SuccesBox(validationResult.Message);
                }
                else
                {
                    Show.ErrorBox(validationResult.Message);

                    this.IsFormEnabled = true;
                    this.NotifyOfPropertyChange(() => this.IsFormEnabled);
                }
            }
            catch (ExternalLoginException exception)
            {
                Show.ErrorBox(exception.Message);

                this.IsFormEnabled = true;
                this.NotifyOfPropertyChange(() => this.IsFormEnabled);
            }
        }

        public void RegisterButton() => Show.RegistrationBox(this.HttpDataService);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;

        private HttpDataService HttpDataService { get; set; }
    }
}
