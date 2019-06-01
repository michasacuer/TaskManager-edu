namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class InfoProjectHelper
    {
        public async void EditProject(Project project)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Put(project, project.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
