using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class NotificationsViewModel : Screen
    {
        public void CancelButton()
        {
            TryClose();
        }
    }
}
