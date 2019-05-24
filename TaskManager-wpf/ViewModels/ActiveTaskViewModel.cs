namespace TaskManager.WPF.ViewModels
{
    using System;
    using Caliburn.Micro;
    using TaskManager.Models;

    public class ActiveTaskViewModel : Screen
    {
        public ActiveTaskViewModel(Task task, string projectName)
        {
            this.projectName = projectName;
            this.activeTask = task;
            this.ActiveTaskTextBlock = $"{task.Name}, Priorytet: {task.Priority}";
            this.DescriptionTextBlock = task.Description;
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

        private string projectName;

        private Task activeTask;
    }
}
