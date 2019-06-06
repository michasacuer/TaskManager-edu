namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteFromDatabaseHelper
    {
        public async void DeleteProject(Project project)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Delete(project, project.Id);
            }
            catch (InternalServerErrorException exception)
            {
                Show.ErrorBox(exception.Message);
            }
            finally
            {
                await Repository.Instance.FetchUpdates();
            }
        }

        public async void DeleteTask(Task task)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Delete(task, task.Id);
            }
            catch (InternalServerErrorException exception)
            {
                Show.ErrorBox(exception.Message);
            }
            finally
            {
                await Repository.Instance.FetchUpdates();
            }
        }
    }
}
