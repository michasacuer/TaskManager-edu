namespace TaskManager.WPF.Helpers
{
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteProjectHelper
    {
        public async void DeleteProjectFromDatabase(TaskManager.Models.Project project)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(project, project.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
