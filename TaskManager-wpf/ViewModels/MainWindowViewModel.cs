namespace TaskManager.WPF.ViewModels
{
    using System;
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

        public void LoadUserInfoPage() => this.ActivateItemAsync(new UserInfoViewModel(this.LoggedUser));

        public void LoadTaskManagerPage()
        {
            this.ActivateItemAsync(new TaskManagerViewModel(this.LoggedUser, this.repository));

            if (!this.LoggedUser.GetUserTask().IsTaskTakenByUser())
            {
                this.IsActiveTaskButtonVisible = Visibility.Visible;
                this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
            }
        }

        public void LoadNotificationsPage() => this.ActivateItemAsync(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => this.ActivateItemAsync(new AddNewTaskViewModel(this.LoggedUser, this.repository));

        public void LoadActiveTaskPage() => Show.ActiveTaskBox(this.LoggedUser.GetUserTask());

        protected async override void OnViewLoaded(object view)
        {
            Show.LoginBox(this.LoggedUser);

            try
            {
                if (await this.LoggedUser.GetUserTask().IsUserHaveActiveTask(this.LoggedUser.User.Id))
                {
                    this.IsActiveTaskButtonVisible = Visibility.Visible;
                    this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
                }
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
    }
}