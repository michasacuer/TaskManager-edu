namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class EndedTasksDataGridViewModel : Screen
    {
        public EndedTasksDataGridViewModel()
        {
            this.EndedTasks = (List<TaskManager.Models.EndedTask>)Repository.Instance.EndedTasks;
        }

        public List<TaskManager.Models.EndedTask> EndedTasks { get; set; }
    }
}