namespace TaskManager.WPF.Helpers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class DeleteTaskHelper
    {
        public async void DeleteTaskFromDatabase(TaskManager.Models.Task task)
        {
            var httpDataService = new HttpDataService();
            await httpDataService.Delete(task, task.Id);
            await Repository.Instance.FetchAll();
        }
    }
}
