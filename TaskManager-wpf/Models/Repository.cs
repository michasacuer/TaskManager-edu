namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public static Repository Instance { get; } = new Repository();

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public IEnumerable<TaskManager.Models.Task> Tasks { get; set; }

        public IEnumerable<TaskManager.Models.EndedTask> EndedTasks { get; set; }

        public async Task FetchAll()
        {
            var httpDataService = new HttpDataService();

            this.Projects = await httpDataService.Get<TaskManager.Models.Project>();
            this.Tasks = await httpDataService.Get<TaskManager.Models.Task>();
            this.EndedTasks = await httpDataService.Get<TaskManager.Models.EndedTask>();
        }
    }
}
