namespace TaskManager.WPF.Models
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Helpers;

    public class ActiveTask
    {
        private TaskManager.Models.Task Task { get; set; }

        public string GetTaskName() => this.Task.Name;

        public string GetTaskDescription() => this.Task.Description;

        public string GetTaskStartTime() => this.Task.StartTime.ToString();

        public string GetTaskPriority() => this.Task.Priority.ToString();

        public bool IsTaskTakenByUser() => this.Task != null;

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

        public async Task EndActiveTask()
        {
            await new ActiveTaskHelper().EndActiveTask(this.Task);
            await Repository.Instance.FetchAll();

            this.Task = null;
        }
    }
}
