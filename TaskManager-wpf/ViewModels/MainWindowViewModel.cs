namespace TaskManager.WPF.ViewModels
{
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly Repository repository = Repository.Instance;

        public MainWindowViewModel()
        {
            this.LoggedUser = new LoggedUser();
        }

        public Visibility IsActiveTaskButtonVisible { get; set; } = Visibility.Hidden;

        private LoggedUser LoggedUser { get; set; }

        public void LoadUserInfoPage() => this.ActivateItem(new UserInfoViewModel(this.LoggedUser));

        public void LoadTaskManagerPage() => this.ActivateItem(new TaskManagerViewModel(this.LoggedUser, this.repository));

        public void LoadNotificationsPage() => this.ActivateItem(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => this.ActivateItem(new AddNewTaskViewModel(this.LoggedUser, this.repository));

        public void LoadActiveTaskPage() => this.ActivateItem(new ActiveTaskViewModel(this.LoggedUser.GetUserTask(), null));

        protected async override void OnViewLoaded(object view)
        {
            Show.LoginBox(this.LoggedUser);

            if (await this.LoggedUser.GetUserTask().IsUserHaveActiveTask(this.LoggedUser.User.Id))
            {
                this.IsActiveTaskButtonVisible = Visibility.Visible;
                this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
            }
        }
    }
}