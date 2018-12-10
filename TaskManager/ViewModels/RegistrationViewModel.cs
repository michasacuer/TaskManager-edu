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

        public bool ManagerChecked { get; set; }
        public bool DeveloperChecked { get; set; }
        public bool ViewerChecked { get; set; }
        
        public RegistrationViewModel(FakeData context)
        {
            TextBoxesInitialize();
            this.context = context;
        }
        public void AcceptButton()
        {
            try { Position = Registration.SetJob(ManagerChecked, DeveloperChecked, ViewerChecked); }
            catch { manager.ShowDialog(new ErrorBoxViewModel("Wybierz stanowisko!"), null, null); return; }

            User userToCheck = new User(LoginTextBox, "", FirstNameTextBox, LastNameTextBox, EmailTextBox, Position);
            (bool isValid, string alert) = Registration.IsValid(userToCheck, context);

            if (isValid)
            {
                context.AddUser(userToCheck);
                manager.ShowDialog(new SuccesBoxViewModel(alert), null, null);
                TryClose();
            }
            else
                manager.ShowDialog(new ErrorBoxViewModel(alert), null, null);
        }

        public void CancelButton() => TryClose();

        private void TextBoxesInitialize()
        {
            LoginTextBox = "Wpisz swój Login";
            FirstNameTextBox = "Wpisz swoje Imie";
            LastNameTextBox = "Wpisz swoje Nazwisko";
            EmailTextBox = "Wpisz swój Email";
        }

        private IWindowManager manager = new WindowManager();
        private FakeData context;
    }
}
