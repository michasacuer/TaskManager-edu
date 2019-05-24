namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<TaskManager.Models.Task>)Repository.Instance.Tasks;
        }

        public List<TaskManager.Models.Task> Tasks { get; set; }
    }
}
