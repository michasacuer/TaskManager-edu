namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class InfoHelper
    {
        public async void EditTask(Task task)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Put(task, task.Id);
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

        public async void EditProject(Project project)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Put(project, project.Id);
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
