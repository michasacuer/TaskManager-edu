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
                manager.ShowDialog(new SuccesBoxViewModel("Zalogowano Pomyślnie!"), null, null);
                loggedUser.LoginUserToApp(context.GetUser(LoginTextBox));
                TryClose();
            }
            else
                manager.ShowDialog(new ErrorBoxViewModel("Błędne dane logowania!"), null, null);
        }

        public void RegisterButton() => manager.ShowWindow(new RegistrationViewModel(context), null, null);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;
        private FakeData context;
        private IWindowManager manager = new WindowManager();
    }
}
