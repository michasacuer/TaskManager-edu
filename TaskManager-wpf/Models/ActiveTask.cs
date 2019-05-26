namespace TaskManager.WPF.Models
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Helpers;

    public class ActiveTask
    {
        public TaskManager.Models.Task Task { get; set; }

        public bool IsTaskTakenByUser() => this.Task == null;

        public async Task<bool> IsUserHaveActiveTask(string userId)
        {
            var task = await new ActiveTaskHelper().IsUserHaveActiveTask(userId);

            if (task != null)
            {
                this.Task = task;
                return true;
            }

            return false;
        }

        public async void EndActiveTask()
        {
            await new ActiveTaskHelper().EndActiveTask(this.Task);
            Repository.Instance.FetchAll();

            this.Task = null;
        }
    }
}
