namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class UserInfoViewModel : Screen
    {
        private MainWindowViewModel vm;

        public UserInfoViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;

            this.LoggedUserFullName = LoggedUser.Instance.GetFullName();
            this.LoggedUserJob = LoggedUser.Instance.GetPosition();

            this.NotifyOfPropertyChange(() => this.LoggedUserJob);
            this.NotifyOfPropertyChange(() => this.LoggedUserFullName);
        }

        public string LoggedUserFullName { get; set; }

        public string LoggedUserJob { get; set; }

        public void LogoutButton()
        {
            this.vm.IsActiveTaskButtonVisible = Visibility.Hidden;
            this.vm.NotifyOfPropertyChange(() => this.vm.IsActiveTaskButtonVisible);

            LoggedUser.Instance.Logout();
            this.TryCloseAsync();

            Show.LoginBox(this.vm);
        }

        public void LoadManagerPanel() => Show.ManagerPanelBox();

        public void OkButton() => this.TryCloseAsync();

        public void ExitButton() => Application.Current.Shutdown();
    }
}
