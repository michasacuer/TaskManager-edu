namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        protected override void OnViewLoaded(object view) => Show.LoginBox(this.loggedUser);

        public void LoadUserInfoPage() => this.ActivateItem(new UserInfoViewModel(this.loggedUser));

        public void LoadTaskManagerPage() => this.ActivateItem(new TaskManagerViewModel(this.loggedUser, this.repository));

        public void LoadNotificationsPage() => this.ActivateItem(new NotificationsViewModel(this.context));

        public void LoadAddNewTaskPage() => this.ActivateItem(new AddNewTaskViewModel(this.loggedUser, this.repository));

        private readonly LoggedUser loggedUser = new LoggedUser();

        private readonly FakeData context = new FakeData();

        private readonly Repository repository = Repository.Instance;
    }
}