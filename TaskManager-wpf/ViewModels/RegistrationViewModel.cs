namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Services;

    internal class RegistrationViewModel : Screen
    {
        public RegistrationViewModel(FakeData context, HttpDataService httpDataService)
        {
            this.TextBoxesInitialize();
            this.context = context;
            this.httpDataService = httpDataService;
        }

        public string LoginTextBox { get; set; }

        public string FirstNameTextBox { get; set; }

        public string PasswordTextBox { get; set; }

        public string LastNameTextBox { get; set; }

        public string EmailTextBox { get; set; }

        public Role Role { get; set; }

        public bool ManagerChecked { get; set; }

        public bool DeveloperChecked { get; set; }

        public bool ViewerChecked { get; set; }


        public async void AcceptButton()
        {
            try
            {
                this.Role = Registration.SetJob(this.ManagerChecked, this.DeveloperChecked, this.ViewerChecked);
            }
            catch
            {
                Show.ErrorBox("Wybierz stanowisko!");
                return;
            }

            RegistrationBindingModel account = new RegistrationBindingModel
            {
                UserName = this.LoginTextBox,
                Password = this.PasswordTextBox,
                FirstName = this.FirstNameTextBox,
                LastName = this.LastNameTextBox,
                Email = this.EmailTextBox,
                Role = this.Role
            };

            (bool isValid, string alert) = Registration.IsValid(account, this.context);

            if (isValid)
            {
                await this.httpDataService.Register(account);
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

        private HttpDataService httpDataService;
    }
}
