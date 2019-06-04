namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteFromDatabaseHelper
    {
        public async void DeleteProject(Project project)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(project, project.Id);

            await Repository.Instance.FetchAll();
        }

        public async void DeleteTask(Task task)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(task, task.Id);

            await Repository.Instance.FetchAll();
        }
    }
}
