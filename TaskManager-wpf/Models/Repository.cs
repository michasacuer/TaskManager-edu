namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public Repository(HttpDataService httpDataService)
        {
            this.HttpDataService = httpDataService;
        }

        private List<Project> Projects { get; set; }

        private List<Task> Tasks { get; set; }

        private HttpDataService HttpDataService { get; set; }
    }
}
