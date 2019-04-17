namespace TaskManager.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Enums;
    using TaskManager.Models;
    using TaskManager.Services;

    internal class RegistrationViewModel : Screen
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
            this.TextBoxesInitialize();
            this.context = context;
        }

        public void AcceptButton()
        {
            try
            {
                this.Position = Registration.SetJob(this.ManagerChecked, this.DeveloperChecked, this.ViewerChecked);
            }
            catch
            {
                Show.ErrorBox("Wybierz stanowisko!");
                return;
            }

            User userToCheck = new User(
                this.LoginTextBox, string.Empty,
                this.FirstNameTextBox,
                this.LastNameTextBox,
                this.EmailTextBox,
                this.Position);

            (bool isValid, string alert) = Registration.IsValid(userToCheck, this.context);

            if (isValid)
            {
                this.context.AddUser(userToCheck);
                Show.SuccesBox(alert);
                this.TryClose();
            }
            else
            {
                Show.ErrorBox(alert);
            }
        }

        public void CancelButton() => this.TryClose();

        private void TextBoxesInitialize()
        {
            this.LoginTextBox = "Wpisz swój Login";
            this.FirstNameTextBox = "Wpisz swoje Imie";
            this.LastNameTextBox = "Wpisz swoje Nazwisko";
            this.EmailTextBox = "Wpisz swój Email";
        }

        private FakeData context;
    }
}
