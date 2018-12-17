using Caliburn.Micro;
using TaskManager.Enums;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    class RegistrationViewModel : Screen
    {
        public string LoginTextBox     { get; set; }
        public string FirstNameTextBox { get; set; }
        public string LastNameTextBox  { get; set; }
        public string EmailTextBox     { get; set; }
        public Position Position       { get; set; }

        public bool ManagerChecked     { get; set; }
        public bool DeveloperChecked   { get; set; }
        public bool ViewerChecked      { get; set; }
        
        public RegistrationViewModel(FakeData context)
        {
            TextBoxesInitialize();
            this.context = context;
        }

        public void AcceptButton()
        {
            try { Position = Registration.SetJob(ManagerChecked, DeveloperChecked, ViewerChecked); }
            catch { Show.ErrorBox("Wybierz stanowisko!"); return; }

            User userToCheck = new User(LoginTextBox, "", FirstNameTextBox, LastNameTextBox, EmailTextBox, Position);
            (bool isValid, string alert) = Registration.IsValid(userToCheck, context);

            if (isValid)
            {
                context.AddUser(userToCheck);
                Show.SuccesBox(alert);
                TryClose();
            }
            else
                Show.ErrorBox(alert);
        }

        public void CancelButton() => TryClose();

        private void TextBoxesInitialize()
        {
            LoginTextBox = "Wpisz swój Login";
            FirstNameTextBox = "Wpisz swoje Imie";
            LastNameTextBox = "Wpisz swoje Nazwisko";
            EmailTextBox = "Wpisz swój Email";
        }

        private FakeData context;
    }
}
