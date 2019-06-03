namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<Task>)Repository.Instance.Tasks;
        }

        public List<Task> Tasks { get; set; }

        public void InfoButton(Task task)
        {
            Show.InfoTaskBox(task);
        }

        public void DeleteButton(TaskManager.Models.Task task)
        {
            if (LoggedUser.Instance.IsManager())
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
