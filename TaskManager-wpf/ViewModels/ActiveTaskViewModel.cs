namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class ActiveTaskViewModel : Screen
    {
        private readonly string projectName;

        public ActiveTaskViewModel(ActiveTask activeTask)
        {
            this.projectName = Repository.Instance.Projects.Single(p => p.Id == activeTask.Task.ProjectId).Name;
            this.ActiveTaskTextBlock = $"{activeTask.Task.Name}, Priorytet: {activeTask.Task.Priority}";
            this.DescriptionTextBlock = activeTask.Task.Description;
            this.TimerActiveTaskTextBlock = DateTime.Now.ToString();
            this.NotifyOfPropertyChange(() => this.TimerActiveTaskTextBlock);
        }

        public string ActiveTaskTextBlock { get; set; }

        public string DescriptionTextBlock { get; set; }

        public string TimerActiveTaskTextBlock { get; set; }

        public void EndTaskButton()
        {
            this.TryClose();
        }

        public void CancelTaskButton() => this.TryClose();
    }
}
