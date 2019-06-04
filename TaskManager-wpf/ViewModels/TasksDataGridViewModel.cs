namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<Task>)Repository.Instance.Tasks;
        }

        public List<Task> Tasks { get; set; }

        public async void InfoButton(Task task)
        {
            Show.InfoTaskBox(task);

            await Repository.Instance.FetchAll();

            var httpDataService = new HttpDataService();
            var temp = await httpDataService.Get<TaskManager.Models.Task>();
            this.Tasks = (List<TaskManager.Models.Task>)temp;

            this.NotifyOfPropertyChange(() => this.Tasks);
        }

        public async void DeleteButton(TaskManager.Models.Task task)
        {
            if (LoggedUser.Instance.IsManager())
            {
                Show.DeleteTaskBox(task);

                await Repository.Instance.FetchAll();

                var httpDataService = new HttpDataService();
                var temp = await httpDataService.Get<TaskManager.Models.Task>();
                this.Tasks = (List<TaskManager.Models.Task>)temp;

                this.NotifyOfPropertyChange(() => this.Tasks);
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do usuwania zadań!");
            }
        }
    }
}
