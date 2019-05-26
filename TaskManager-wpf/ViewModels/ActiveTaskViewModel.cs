namespace TaskManager.WPF.ViewModels
{
    using System;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Models;

    public class ActiveTaskViewModel : Screen
    {
        public ActiveTaskViewModel(ActiveTask activeTask, string projectName)
        {
            this.projectName = projectName;
            this.activeTask = activeTask.Task;
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

        private string projectName;

        private Task activeTask;
    }
}
