namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Services;

    public class NotificationsViewModel : Screen
    {
        public NotificationsViewModel()
        {
            NotificationsHubService.Instance.SetReferenceToViewModel(this);
        }

        public BindableCollection<string> Notifications { get; set; }

        public void CancelButton()
        {
            NotificationsHubService.Instance.SetViewModelToNull();
            this.TryCloseAsync();
        }
    }
}
