namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public Repository()
        {
            this.FetchAll();
        }

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public async void FetchAll()
        {
            var httpDataService = new HttpDataService();

            this.Projects = await httpDataService.Get<TaskManager.Models.Project>();
        }
    }
}
