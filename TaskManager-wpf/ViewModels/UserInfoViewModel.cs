namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class UserInfoViewModel : Screen
    {
        public UserInfoViewModel()
        {
            this.LoggedUserFullName = LoggedUser.Instance.GetFullName();
            this.LoggedUserJob = LoggedUser.Instance.GetPosition();

            this.NotifyOfPropertyChange(() => this.LoggedUserJob);
            this.NotifyOfPropertyChange(() => this.LoggedUserFullName);
        }

        public string LoggedUserFullName { get; set; }

        public string LoggedUserJob { get; set; }

        public void LogoutButton()
        {
            LoggedUser.Instance.Logout();
            this.TryCloseAsync();
            Show.LoginBox();
        }

        public void LoadManagerPanel() => Show.ManagerPanelBox();

        public void OkButton() => this.TryCloseAsync();

        public void ExitButton() => Application.Current.Shutdown();
    }
}
