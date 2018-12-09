using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {

        protected override void OnViewLoaded(object view) => 
            manager.ShowDialog(new LoginViewModel(context, loggedUser), null, null);

        public void LoadUserInfoPage() => ActivateItem(new UserInfoViewModel(loggedUser));

        public void LoadTaskManagerPage() => ActivateItem(new TaskManagerViewModel());

        public void LoadNotificationsPage() => ActivateItem(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => ActivateItem(new AddNewTaskViewModel());

        private LoggedUser loggedUser = new LoggedUser();
        private IWindowManager manager = new WindowManager();
        private FakeData context = new FakeData();

    }
}
