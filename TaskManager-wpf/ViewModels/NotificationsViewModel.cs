namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class NotificationsViewModel : Screen
    {
        public BindableCollection<string> EndedTasksList { get; set; }

        public NotificationsViewModel()
        {
            this.NotifyOfPropertyChange(() => this.EndedTasksList);
        }

        public void CancelButton() => this.TryCloseAsync();
    }
}
