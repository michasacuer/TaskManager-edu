namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Diagnostics;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    internal class ActiveTaskViewModel : Screen
    {
        public string ActiveTaskTextBlock { get; set; }

        public string DescriptionTextBlock { get; set; }

        public string TimerActiveTaskTextBlock { get; set; }

        public ActiveTaskViewModel(Task task, FakeData context, string projectName)
        {
            this.projectName = projectName;
            this.context = context;
            this.stopwatch.Start();
            this.activeTask = task;
            this.ActiveTaskTextBlock = $"{task.Name}, Priorytet: {task.Priority}";
            this.DescriptionTextBlock = task.Description;
            this.TimerActiveTaskTextBlock = DateTime.Now.ToString();
            this.NotifyOfPropertyChange(() => this.TimerActiveTaskTextBlock);
        }

        public void EndTaskButton()
        {
            this.context.EndTask(this.activeTask, this.projectName);
            this.TryClose();
        }

        public void CancelTaskButton() => this.TryClose();

        private string projectName;
        private FakeData context;
        private Stopwatch stopwatch = new Stopwatch();
        private Task activeTask;
    }
}
