namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    public class ManagerPanelViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ManagerPanelViewModel()
        {
            this.Items.Add(new ProjectsDataGridViewModel { DisplayName = "Projekty" });
            this.Items.Add(new TasksDataGridViewModel { DisplayName = "Zadania" });
            this.Items.Add(new EndedTasksDataGridViewModel { DisplayName = "Skończone zadania" });
        }

        public void ExitButton() => this.TryCloseAsync();
    }
}
