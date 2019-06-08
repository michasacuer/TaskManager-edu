namespace TaskManager.Models.ViewModels
{
    using System.Collections.Generic;

    public class ProjectRaportViewModel
    {
        public Project Project { get; set; }

        public List<Task> ProjectTasks { get; set; }

        public List<EndedTask> ProjectEndedTasks { get; set; }

        public int SpentStoryPoints { get; set; }

        public int RemainingStoryPoints { get; set; }
    }
}
