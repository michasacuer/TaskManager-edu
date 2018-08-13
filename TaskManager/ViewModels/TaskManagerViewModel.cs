using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class TaskManagerViewModel : Screen
    {
        public void CancelButton()
        {
            TryClose();
        }
    }
}
