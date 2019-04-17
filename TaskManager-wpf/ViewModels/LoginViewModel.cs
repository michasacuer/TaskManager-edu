namespace TaskManager.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.Services;

    internal class LoginViewModel : Screen
    {
        public string LoginTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public LoginViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
        }

        public void LoginButton()
        {
            if (Validation.IsLoginValid(this.LoginTextBox, this.PasswordTextBox, this.context))
            {
                this.TryClose();
                Show.SuccesBox("Zalogowano pomyślnie!");
                this.loggedUser.LoginUserToApp(this.context.GetUser(this.LoginTextBox));
            }
            else
            {
                Show.ErrorBox("Błędne dane logowania!");
            }
        }

        public void RegisterButton() => Show.RegistrationBox(this.context);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;
        private FakeData context;
    }
}
