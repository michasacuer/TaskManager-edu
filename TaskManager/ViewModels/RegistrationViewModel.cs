using Caliburn.Micro;
using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    class RegistrationViewModel : Screen
    {
        public string LoginTextBox { get; set; }
        public string FirstNameTextBox { get; set; }
        public string LastNameTextBox { get; set; }
        public string EmailTextBox { get; set; }
        public Position Position { get; set; }

        public RegistrationViewModel(FakeData context) => this.context = context;

        public void AcceptButton()
        {
            User userToCheck = new User(LoginTextBox, "", FirstNameTextBox, LastNameTextBox, EmailTextBox, Position);
            (bool isValid, string alert) = Registration.IsRegistrationValid(userToCheck, context);

            if (isValid)
            {
                context.AddUser(userToCheck);
                manager.ShowWindow(new SuccesBoxViewModel(alert), null, null);
                TryClose();
            }
            else
                manager.ShowWindow(new ErrorBoxViewModel(alert), null, null);
        }

        public void CancelButton() => TryClose();

        private IWindowManager manager = new WindowManager();
        private FakeData context;
    }
}
