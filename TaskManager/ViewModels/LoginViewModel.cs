using Caliburn.Micro;
using System.Windows;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    class LoginViewModel : Screen
    {
        public string Login    { get; set; }
        public string Password { get; set; }

        public LoginViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
        }

        public void LoginButton()
        {
            if (Validation.IsLoginValid(Login, Password, context))
            {
                manager.ShowWindow(new SuccesBoxViewModel("Zalogowano Pomyślnie!"), null, null);
                loggedUser.LoginUserToApp(context.GetUser(Login));
                TryClose();
            }
            else
                manager.ShowDialog(new ErrorBoxViewModel("Błędne dane logowania!"), null, null);
        }

        public void RegisterButton() => manager.ShowWindow(new RegistrationViewModel(), null, null);

        public void CancelButton() => Application.Current.Shutdown();

        private LoggedUser loggedUser;
        private FakeData context;
        private IWindowManager manager = new WindowManager();
    }
}
