using Caliburn.Micro;

namespace TaskManager.ViewModels 
{
    class SuccesBoxViewModel : Screen
    {
        public string SuccesTextBox { get; set; }
        public SuccesBoxViewModel(string alert) => SuccesTextBox = alert;
        public void OkButton() => TryClose();
    }
}
