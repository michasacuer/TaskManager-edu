namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;

    public class Project
    {
        public string ProjectName { get; private set; }

        public List<Task> Tasks { get; private set; }

        public List<Task> EndedTasks { get; private set; }

        public Project(string projectName, List<Task> tasks)
        {
            this.ProjectName = projectName;
            this.Tasks = tasks;
            this.EndedTasks = new List<Task>();
        }

        public Project(string projectName)
            : this(projectName, new List<Task>())
        {
        }
    }
}
