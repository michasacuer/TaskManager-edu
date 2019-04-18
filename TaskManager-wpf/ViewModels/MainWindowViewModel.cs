namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    internal class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        protected override void OnViewLoaded(object view) => Show.LoginBox(this.context, this.loggedUser);

        public void LoadUserInfoPage() => this.ActivateItem(new UserInfoViewModel(this.context, this.loggedUser));

        public void LoadTaskManagerPage() => this.ActivateItem(new TaskManagerViewModel(this.context, this.loggedUser));

        public void LoadNotificationsPage() => this.ActivateItem(new NotificationsViewModel(this.context));

        public void LoadAddNewTaskPage() => this.ActivateItem(new AddNewTaskViewModel(this.context, this.loggedUser));

        private readonly LoggedUser loggedUser = new LoggedUser();

        private readonly FakeData context = new FakeData();
    }
}
