namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using System.Collections.Generic;
    using TaskManager.WPF.Models;

    public class ManagerPanelViewModel : Conductor<IScreen>.Collection.OneActive
    { 
        public void LoadProjectsDataGrid() => this.ActivateItem(new ProjectsDataGridViewModel());

        public void ExitButton() => this.TryClose();
    }
}
