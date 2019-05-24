namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    public class ManagerPanelViewModel : Screen
    {
        public void ExitButton() => this.TryClose();
    }
}
