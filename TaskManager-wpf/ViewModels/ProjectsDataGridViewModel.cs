namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class ProjectsDataGridViewModel : Screen
    {
        public List<TaskManager.Models.Project> Projects { get; set; } = (List<TaskManager.Models.Project>)Repository.Instance.Projects;
    }
}
