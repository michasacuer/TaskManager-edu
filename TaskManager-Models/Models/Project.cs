namespace TaskManager.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        public Project()
        {
        }

        [Key]
        public int Id { get; set; }

        public string Tag { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}
