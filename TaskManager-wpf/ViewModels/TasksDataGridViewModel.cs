namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class TasksDataGridViewModel : Screen
    {
        public TasksDataGridViewModel()
        {
            this.Tasks = (List<TaskManager.Models.Task>)Repository.Instance.Tasks;
        }

        public List<TaskManager.Models.Task> Tasks { get; set; }

        public async void InfoButton(TaskManager.Models.Task task)
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
            if (LoggedUser.Instance.HavePermissionToDelete())
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
