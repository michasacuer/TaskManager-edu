namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class EndedTasksDataGridViewModel : Screen
    {
        public EndedTasksDataGridViewModel()
        {
            this.Tasks = (List<TaskManager.Models.Task>)Repository.Instance.Tasks;
        }

        public List<TaskManager.Models.Task> Tasks { get; set; }
    }
}