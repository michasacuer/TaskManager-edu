using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Task
    {
        private string TaskName { get; set; }
        private Priority Priority { get; set; }
        private string Description { get; set; }

        public Task(string taskName, Priority priority, string desc)
        {
            TaskName = TaskName;
            Priority = priority;
            Description = desc;
        }
    }
}
