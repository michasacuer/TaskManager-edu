namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteProjectHelper
    {
        public async void DeleteProjectFromDatabase(Project project)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(project, project.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
