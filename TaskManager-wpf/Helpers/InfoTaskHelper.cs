namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class InfoTaskHelper
    {
        public async void EditTask(Task task)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Put(task, task.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
