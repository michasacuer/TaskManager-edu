namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    public class SuccesBoxViewModel : Screen
    {
        public string SuccesTextBox { get; set; }

        public SuccesBoxViewModel(string alert) => this.SuccesTextBox = alert;

        public void OkButton() => this.TryClose();
    }
}
