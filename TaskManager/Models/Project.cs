using System.Collections.Generic;

namespace TaskManager.Models
{
    public class Project
    {
        private string ProjectName { get; set; }
        private List<Task> Tasks { get; set; }

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
