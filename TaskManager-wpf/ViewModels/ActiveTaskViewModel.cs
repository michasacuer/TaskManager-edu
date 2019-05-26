namespace TaskManager.WPF.ViewModels
{
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class ActiveTaskViewModel : Screen
    {
        private readonly string projectName;

        private readonly ActiveTask activeTask;

        public ActiveTaskViewModel(ActiveTask activeTask)
        {
            this.activeTask = activeTask;

            this.projectName = Repository.Instance.Projects.Single(p => p.Id == activeTask.Task.ProjectId).Name;
            this.ActiveTaskTextBlock = $"{activeTask.Task.Name}, Priorytet: {activeTask.Task.Priority}";
            this.DescriptionTextBlock = activeTask.Task.Description;
            this.TimerActiveTaskTextBlock = activeTask.Task.StartTime.ToString();
            this.NotifyOfPropertyChange(() => this.TimerActiveTaskTextBlock);
        }

        public string ActiveTaskTextBlock { get; set; }

        public string DescriptionTextBlock { get; set; }

        public string TimerActiveTaskTextBlock { get; set; }

        public void EndTaskButton() => this.activeTask.EndActiveTask();

        public void CancelTaskButton() => this.TryClose();
    }
}
