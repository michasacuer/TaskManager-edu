using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public void LoadLoginPage()
        {
            ActivateItem(new LoginViewModel());
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
    }
}
