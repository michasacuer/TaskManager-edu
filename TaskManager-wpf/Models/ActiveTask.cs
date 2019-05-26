namespace TaskManager.WPF.Models
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Services;

    public class ActiveTask
    {
        public TaskManager.Models.Task Task { get; set; }

        public bool IsTaskTakenByUser() => this.Task == null;

        public async Task<bool> IsUserHaveActiveTask(string userId)
        {
            var httpDataService = new HttpDataService();

            var task = await httpDataService.Get<TaskManager.Models.Task>(userId);

            if (task != null)
            {
                this.Task = task;
                return true;
            }

            return false;
        }
    }
}
