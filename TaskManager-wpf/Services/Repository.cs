namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public Repository()
        {
            this.FetchAll();
        }

        public static Repository Instance { get; } = new Repository();

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public IEnumerable<TaskManager.Models.Task> Tasks { get; set; }

        public async void FetchAll()
        {
            //test
            var httpDataService = new HttpDataService();

            this.Projects = await httpDataService.Get<TaskManager.Models.Project>();
            this.Tasks = await httpDataService.Get<TaskManager.Models.Task>();
        }
    }
}
