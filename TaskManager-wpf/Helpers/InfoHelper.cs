namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class InfoHelper
    {
        public void EditTask(Task task) => this.EditItemInDatabase(task, task.Id);

        public void EditProject(Project project) => this.EditItemInDatabase(project, project.Id);

        public async void EditItemInDatabase<TObject>(TObject item, int itemId)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Put(item, itemId);
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
