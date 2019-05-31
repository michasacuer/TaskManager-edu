namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<TaskManager.Models.Task>)Repository.Instance.Tasks;
        }

        public List<TaskManager.Models.Task> Tasks { get; set; }

        public void DeleteButton(TaskManager.Models.Task task)
        {
            if (LoggedUser.Instance.HavePermissionToDelete())
            {
                Show.DeleteTaskBox(task);
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do usuwania zadań!");
            }
        }
    }
}
