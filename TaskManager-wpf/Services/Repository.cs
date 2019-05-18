namespace TaskManager.WPF.Models
{
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public Repository()
        {
            this.FetchAll();
        }

        public BindableCollection<TaskManager.Models.Project> Projects { get; set; }

        public BindableCollection<TaskManager.Models.Task> Tasks { get; set; }

        public async Task<BindableCollection<TObject>> Fetch<TObject>()
        {
            var httpDataService = new HttpDataService();

            return new BindableCollection<TObject>(await httpDataService.Get<TObject>());
        }

        public async void FetchAll()
        {
            var httpDataService = new HttpDataService();

            this.Projects = new BindableCollection<TaskManager.Models.Project>(await httpDataService.Get<TaskManager.Models.Project>());
            this.Tasks = new BindableCollection<TaskManager.Models.Task>(await httpDataService.Get<TaskManager.Models.Task>());
        }
    }
}
