namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class DeleteTaskHelper
    {
        public async void DeleteTaskFromDatabase(Task task)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(task, task.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
