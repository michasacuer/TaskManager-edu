namespace TaskManager.Models.ViewModels
{
    using System.Collections.Generic;

    public class ProjectRaportViewModel
    {
        public Project Project { get; set; }

        public List<Task> Tasks { get; set; }

        public List<EndedTask> EndedTasks { get; set; }

        public int SpentStoryPoints { get; set; }

        public int RemainingStoryPoints { get; set; }
    }
}
