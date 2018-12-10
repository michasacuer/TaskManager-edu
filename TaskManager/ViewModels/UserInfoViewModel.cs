using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class UserInfoViewModel : Screen
    {
        public string LoggedUserFullName { get; set; }
        public string LoggedUserJob { get; set; }

        public UserInfoViewModel(LoggedUser loggedUser, FakeData context)
        {
            this.loggedUser = loggedUser;
            this.context = context;

            LoggedUserFullName = loggedUser.GetFullName();
            LoggedUserJob = loggedUser.GetPosition();

            NotifyOfPropertyChange(() => LoggedUserJob);
            NotifyOfPropertyChange(() => LoggedUserFullName);
        }

        public void LogoutButton()
        {
            loggedUser.LogOut();
            TryClose();
            manager.ShowDialog(new LoginViewModel(context, loggedUser), null, null);
        }

        public void OkButton() => TryClose();

        private IWindowManager manager = new WindowManager();
        private LoggedUser loggedUser;
        private FakeData context;
    }
}
