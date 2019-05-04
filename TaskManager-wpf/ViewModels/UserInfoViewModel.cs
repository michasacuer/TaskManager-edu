namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    internal class UserInfoViewModel : Screen
    {
        public string LoggedUserFullName { get; set; }

        public string LoggedUserJob { get; set; }

        public UserInfoViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.loggedUser = loggedUser;
            this.context = context;

            this.LoggedUserFullName = loggedUser.GetFullName();
            this.LoggedUserJob = loggedUser.GetPosition();

            this.NotifyOfPropertyChange(() => this.LoggedUserJob);
            this.NotifyOfPropertyChange(() => this.LoggedUserFullName);
        }

        public void LogoutButton()
        {
            this.loggedUser.Logout();
            this.TryClose();
            Show.LoginBox(this.context, this.loggedUser, this.httpDataService);
        }

        public void OkButton() => this.TryClose();

        private LoggedUser loggedUser;

        private FakeData context;

        private HttpDataService httpDataService;
    }
}
