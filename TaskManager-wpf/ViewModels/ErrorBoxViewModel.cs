namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    internal class ErrorBoxViewModel : Screen
    {
        public string ErrorTextBox { get; set; }

        public ErrorBoxViewModel(string alert) => this.ErrorTextBox = alert;

        public void OkButton() => this.TryClose();
    }
}
