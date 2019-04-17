namespace TaskManager.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Models;

    internal class NotificationsViewModel : Screen
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
