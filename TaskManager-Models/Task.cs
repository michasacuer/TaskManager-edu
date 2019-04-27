namespace TaskManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using TaskManager.Models.Enums;

    public class Task
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public int? StoryPoints { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}