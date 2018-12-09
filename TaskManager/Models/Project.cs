using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
