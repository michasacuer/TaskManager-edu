namespace TaskManager.WPF.Models
{
    using Caliburn.Micro;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public Repository(HttpDataService httpDataService)
        {
            this.HttpDataService = httpDataService;
        }

        private BindableCollection<Project> Projects { get; set; }

        private BindableCollection<Task> Tasks { get; set; }

        private HttpDataService HttpDataService { get; set; }
    }
}
