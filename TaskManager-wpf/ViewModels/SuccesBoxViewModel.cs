namespace TaskManager.ViewModels 
{
    using Caliburn.Micro;

    internal class SuccesBoxViewModel : Screen
    {
        public string SuccesTextBox { get; set; }

        public SuccesBoxViewModel(string alert) => this.SuccesTextBox = alert;

        public void OkButton() => this.TryClose();
    }
}
