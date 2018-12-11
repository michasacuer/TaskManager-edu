using Caliburn.Micro;
using System.Windows;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    class LoginViewModel : Screen
    {
        public string LoginTextBox    { get; set; }
        public string PasswordTextBox { get; set; }

        public LoginViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
        }

        public void LoginButton()
        {
            if (Validation.IsLoginValid(LoginTextBox, PasswordTextBox, context))
            {
                TryClose();
                Show.SuccesBox("Zalogowano pomyślnie!");
                loggedUser.LoginUserToApp(context.GetUser(LoginTextBox));
            }
            else
                Show.ErrorBox("Błędne dane logowania!");
        }

        public void RegisterButton() => Show.RegistrationBox(context);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;
        private FakeData context;
    }
}
