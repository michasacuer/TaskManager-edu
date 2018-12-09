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

        public LoginViewModel(FakeData context)
        {
            this.context = context;
        }

        public void LoginButton()
        {
            if (Validation.IsValid(Login, Password, context))
            {
                MessageBox.Show("Zalogowano pomyślnie!");
                TryClose();
            }
            else
                MessageBox.Show("Niepoprawne dane logowania!");
        }

        public void RegisterButton()
        {
            IWindowManager manager = new WindowManager();
            RegistrationViewModel registrationView = new RegistrationViewModel();
            manager.ShowWindow(registrationView, null, null);
        }

        public void CancelButton()
        {
            TryClose();
        }

        private FakeData context;
    }
}
