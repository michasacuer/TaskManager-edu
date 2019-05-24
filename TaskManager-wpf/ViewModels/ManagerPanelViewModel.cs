namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    public class ManagerPanelViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ManagerPanelViewModel()
        {
            this.Items.Add(new ProjectsDataGridViewModel { DisplayName = "Projekty" });
            this.Items.Add(new TasksDataGridViewModel { DisplayName = "Zadania" });
        }

        public void ExitButton() => this.TryClose();
    }
}
