using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        protected override void OnViewLoaded(object view) => Show.LoginBox(context, loggedUser);
        public void LoadUserInfoPage()      => ActivateItem(new UserInfoViewModel(context, loggedUser));
        public void LoadTaskManagerPage()   => ActivateItem(new TaskManagerViewModel(context, loggedUser));
        public void LoadNotificationsPage() => ActivateItem(new NotificationsViewModel(context));
        public void LoadAddNewTaskPage()    => ActivateItem(new AddNewTaskViewModel(context, loggedUser));
                        
        private readonly LoggedUser loggedUser = new LoggedUser();
        private readonly FakeData context      = new FakeData();
    }
}
