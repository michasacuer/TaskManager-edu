using Caliburn.Micro;

namespace TaskManager.ViewModels
{
    class ErrorBoxViewModel : Screen
    {
        public string ErrorTextBox { get; set; }

        public ErrorBoxViewModel(string alert) => ErrorTextBox = alert;

        public void OkButton() => TryClose();
    }
}
