using TaskManager.Enums;

namespace TaskManager.Models
{
    public class Task
    {
        public string TaskName    { get; private set; }
        public Priority Priority  { get; private set; }
        public string Description { get; private set; }

        public Task(string taskName, Priority priority, string desc)
        {
            TaskName = taskName;
            Priority = priority;
            Description = desc;
        }
    }
}
