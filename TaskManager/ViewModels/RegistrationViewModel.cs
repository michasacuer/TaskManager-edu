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
            if(LoginTextBox == null || FirstNameTextBox == null ||LastNameTextBox == null || EmailTextBox == null)
            {
                manager.ShowWindow(new ErrorBoxViewModel("Wypełnij wszystkie wymagane pola!"), null, null);
                return;
            }

            if(!Validation.IsEmailValid(EmailTextBox))
            {
                manager.ShowWindow(new ErrorBoxViewModel("Błędny adres email!"), null, null);
                return;
            }

            if(Validation.IsEmailExist(EmailTextBox, context))
            {
                manager.ShowWindow(new ErrorBoxViewModel("Podany Email jest już w bazie!"), null, null);
                return;
            }

            if(Validation.IsLoginExist(LoginTextBox, context))
            {
                manager.ShowWindow(new ErrorBoxViewModel("Podany login jest już w bazie!"), null, null);
                return;
            }

            context.AddUser(new User(LoginTextBox, "", FirstNameTextBox, LastNameTextBox, EmailTextBox, Position));
            manager.ShowWindow(new SuccesBoxViewModel("Zarejestrowano pomyślnie!"), null, null);
            TryClose(); //przeniesc to do sevices xD

        }

        private IWindowManager manager = new WindowManager();
        private FakeData context;
    }
}
