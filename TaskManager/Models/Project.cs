using System.Collections.Generic;

namespace TaskManager.Models
{
    public class Project
    {
        public string ProjectName { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Project(string projectName, List<Task> tasks)
        {
            ProjectName = projectName;
            Tasks = tasks;
        }

        public Project(string projectName)
        {
            ProjectName = projectName;
        }
    }
}
