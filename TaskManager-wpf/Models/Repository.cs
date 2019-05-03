namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;

    public class Repository
    {
        public Repository()
        {
        }

        private List<Project> Projects { get; set; }

        private List<Task> Tasks { get; set; }
    }
}
