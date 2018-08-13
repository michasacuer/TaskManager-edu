using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class AddNewTaskViewModel : Screen
    {
        public void CancelButton()
        {
            TryClose();
        }
    }
}
