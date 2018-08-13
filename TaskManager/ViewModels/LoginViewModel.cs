using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class LoginViewModel : Screen
    {
        public void LoginButton()
        {
            TryClose();
        }

        public void CancelButton()
        {
            TryClose();
        }
    }
}
