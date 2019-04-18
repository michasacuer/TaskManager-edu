namespace TaskManager.Models
{
    using TaskManager.Enums;

    public class Task
    {
        public string TaskName { get; private set; }

        public Priority Priority { get; private set; }

        public string Description { get; private set; }

        public Task(string taskName, Priority priority, string desc)
        {
            this.TaskName = taskName;
            this.Priority = priority;
            this.Description = desc;
        }
    }
}
