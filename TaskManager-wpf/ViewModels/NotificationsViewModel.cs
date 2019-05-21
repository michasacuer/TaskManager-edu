namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class NotificationsViewModel : Screen
    {
        public BindableCollection<string> EndedTasksList { get; set; }

        public NotificationsViewModel(FakeData context)
        {
            this.context = context;
            this.EndedTasksList = context.GetEndedTasks();
            this.NotifyOfPropertyChange(() => this.EndedTasksList);
        }

        public void CancelButton() => TryClose();

        private FakeData context;
    }
}
