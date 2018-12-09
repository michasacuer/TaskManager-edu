using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {

        protected override void OnViewLoaded(object view)
        {
            IWindowManager manager = new WindowManager();
            LoginViewModel loginView = new LoginViewModel(context); //Login page
            manager.ShowDialog(loginView, null, null);
        }

        public void LoadUserInfoPage() //here starts "main" program
        {
            ActivateItem(new UserInfoViewModel());
        }

        public void LoadTaskManagerPage()
        {
            ActivateItem(new TaskManagerViewModel());
        }

        public void LoadNotificationsPage()
        {
            ActivateItem(new NotificationsViewModel());
        }

        public void LoadAddNewTaskPage()
        {
            ActivateItem(new AddNewTaskViewModel());
        }

        private FakeData context = new FakeData();
    }
}
