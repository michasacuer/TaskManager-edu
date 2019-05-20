namespace TaskManager.WPF.Helpers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class TaskManagerHelper
    {
        private readonly Repository repository;

        public TaskManagerHelper(Repository repository)
        {
            this.repository = repository;
        }

        public BindableCollection<string> PopulateTasksList(string selectedProjectsList)
        {
            var tasksList = new BindableCollection<string>();

            var tasks = this.repository.Projects.Single(p => p.Name == selectedProjectsList).Tasks;
            foreach (var task in tasks)
            {
                tasksList.Add(task.Name + " - " + task.Priority.ToString());
            }

            return tasksList;
        }

        public async Task<TaskManager.Models.Task> GetTaskToActivate(string selectedTasksList, string selectedProjectsList)
        {
            var taskId = this.repository
                .Projects.Single(p => p.Name == selectedProjectsList)
                .Tasks.Single(t => t.Name == selectedTasksList).Id;

            var httpDataService = new HttpDataService();
            return await httpDataService.Get<TaskManager.Models.Task>(taskId);
        }
    }
}
