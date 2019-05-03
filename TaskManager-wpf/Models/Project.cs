namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;

    public class Project
    {
        public int Id { get; set; }

        public string Tag { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Task> Tasks { get; set; }

        public List<Task> EndedTasks { get; private set; }

        public Project(string projectName, List<Task> tasks)
        {
            this.Name = projectName;
            this.Tasks = tasks;
            this.EndedTasks = new List<Task>();
        }

        public Project(string projectName)
            : this(projectName, new List<Task>())
        {
        }
    }
}
