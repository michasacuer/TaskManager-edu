using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {

        protected override void OnViewLoaded(object view) => 
            manager.ShowDialog(new LoginViewModel(context, loggedUser), null, null);

        public void LoadUserInfoPage() => ActivateItem(new UserInfoViewModel(loggedUser, context));

        public void LoadTaskManagerPage() => ActivateItem(new TaskManagerViewModel(context, loggedUser));

        public void LoadNotificationsPage() => ActivateItem(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => ActivateItem(new AddNewTaskViewModel(context, loggedUser));

        private LoggedUser loggedUser = new LoggedUser();
        private IWindowManager manager = new WindowManager();
        private FakeData context = new FakeData();

    }
}
