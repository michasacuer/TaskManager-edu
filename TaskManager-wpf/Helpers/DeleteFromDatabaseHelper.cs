namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteFromDatabaseHelper
    {
        public void DeleteProject(Project project) => this.DeleteItemFromDatabase(project, project.Id);

        public void DeleteTask(Task task) => this.DeleteItemFromDatabase(task, task.Id);

        private async void DeleteItemFromDatabase<TObject>(TObject item, int itemId)
        {
            try
            {
                var httpDataService = new HttpDataService();
                await httpDataService.Delete(item, itemId);
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
