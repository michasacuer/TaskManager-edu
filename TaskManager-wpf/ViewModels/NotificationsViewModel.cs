using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class NotificationsViewModel : Screen
    {
        public BindableCollection<string> EndedTasksList { get; set; }

        public NotificationsViewModel(FakeData context)
        {
            this.context = context;
            EndedTasksList = context.GetEndedTasks();
            NotifyOfPropertyChange(() => EndedTasksList);
        }

        public void CancelButton() => TryClose();

        private FakeData context;
    }
}
