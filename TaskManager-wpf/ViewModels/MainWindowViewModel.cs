namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class MainWindowViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public Visibility IsActiveTaskButtonVisible { get; set; } = Visibility.Hidden;

        public void LoadUserInfoPage() => this.ActivateItemAsync(new UserInfoViewModel(this));

        public void LoadTaskManagerPage() => this.ActivateItemAsync(new TaskManagerViewModel(this));

        public void LoadNotificationsPage() => this.ActivateItemAsync(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => this.ActivateItemAsync(new AddNewViewModel());

        public void LoadActiveTaskPage() => Show.ActiveTaskBox(this);

        public void HideBar()
        {
            if (LoggedUser.Instance.GetUserTask().IsTaskTakenByUser())
            {
                this.IsActiveTaskButtonVisible = Visibility.Hidden;
                this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
            }
        }

        public void ShowBar()
        {
            if (LoggedUser.Instance.GetUserTask().IsTaskTakenByUser())
            {
                this.IsActiveTaskButtonVisible = Visibility.Visible;
                this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
            }
        }

        protected async override void OnViewLoaded(object view)
        {
            Show.LoginBox(this);

            try
            {
                await Repository.Instance.FetchAll();

                NotificationsHubService.Instance.Initialize();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
    }
}