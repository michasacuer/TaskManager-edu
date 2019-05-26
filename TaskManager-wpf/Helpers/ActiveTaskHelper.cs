namespace TaskManager.WPF.Helpers
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Services;

    public class ActiveTaskHelper
    {
        public async Task<TaskManager.Models.Task> IsUserHaveActiveTask(string userId)
            => await new HttpDataService().Get<TaskManager.Models.Task>(userId);

        public async Task<TaskManager.Models.Task> EndActiveTask(TaskManager.Models.Task task)
            => await new HttpDataService().Put(task, task.Id.ToString(), task.ApplicationUserId.ToString());
    }
}
