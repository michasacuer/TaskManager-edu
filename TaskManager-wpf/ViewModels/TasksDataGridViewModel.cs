namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using System.Collections.Generic;
    using TaskManager.WPF.Models;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<TaskManager.Models.Project>)Repository.Instance.Tasks;
        }

        public List<TaskManager.Models.Project> Tasks { get; set; }
    }
}
