namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class UserInfoViewModel : Screen
    {
        private readonly LoggedUser loggedUser;

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

        public void LoadManagerPanel() => Show.ManagerPanelBox();

        public void OkButton() => this.TryClose();

        public void ExitButton() => Application.Current.Shutdown();
    }
}
