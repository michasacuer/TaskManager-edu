using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class UserInfoViewModel : Screen
    {   
        public string LoggedUserFullName { get; set; }
        public string LoggedUserJob      { get; set; }

        public UserInfoViewModel(FakeData context, LoggedUser loggedUser)
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
            loggedUser.Logout();
            TryClose();
            Show.LoginBox(context, loggedUser);
        }

        public void OkButton() => TryClose();

        private LoggedUser loggedUser;
        private FakeData   context;
    }
}
