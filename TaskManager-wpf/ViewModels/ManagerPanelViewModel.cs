namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;

    public class ManagerPanelViewModel : Conductor<IScreen>.Collection.OneActive
    { 
        public void LoadProjectsDataGrid() => this.ActivateItem(new ProjectsDataGridViewModel());

        public void LoadTasksDataGrid() => this.ActivateItem(new TasksDataGridViewModel());

        public void ExitButton() => this.TryClose();
    }
}
