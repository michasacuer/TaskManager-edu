namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class UserInfoViewModel : Screen
    {
        public UserInfoViewModel(LoggedUser loggedUser)
        {
            this.loggedUser = loggedUser;

            this.LoggedUserFullName = loggedUser.GetFullName();
            this.LoggedUserJob = loggedUser.GetPosition();

            this.NotifyOfPropertyChange(() => this.LoggedUserJob);
            this.NotifyOfPropertyChange(() => this.LoggedUserFullName);
        }

        public string LoggedUserFullName { get; set; }

        public string LoggedUserJob { get; set; }

        public void LogoutButton()
        {
            this.loggedUser.Logout();
            this.TryClose();
            Show.LoginBox(this.loggedUser);
        }

        public void OkButton() => this.TryClose();

        private LoggedUser loggedUser;

        private HttpDataService httpDataService;
    }
}
