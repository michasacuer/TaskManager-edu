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
        public MainWindowViewModel()
        {
            HubService.Initialize();
        }

        public Visibility IsActiveTaskButtonVisible { get; set; } = Visibility.Hidden;

        public void LoadUserInfoPage() => this.ActivateItemAsync(new UserInfoViewModel());

        public void LoadTaskManagerPage() => this.ActivateItemAsync(new TaskManagerViewModel(this));

        public void LoadNotificationsPage() => this.ActivateItemAsync(new NotificationsViewModel());

        public void LoadAddNewTaskPage() => this.ActivateItemAsync(new AddNewTaskViewModel());

        public void LoadActiveTaskPage() => Show.ActiveTaskBox(this);

        protected async override void OnViewLoaded(object view)
        {
            Show.LoginBox();

            try
            {
                if (LoggedUser.Instance.GetUserTask().IsTaskTakenByUser())
                {
                    this.IsActiveTaskButtonVisible = Visibility.Visible;
                    this.NotifyOfPropertyChange(() => this.IsActiveTaskButtonVisible);
                }

                await Repository.Instance.FetchAll();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
    }
}