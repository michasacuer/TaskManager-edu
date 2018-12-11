using Caliburn.Micro;
using TaskManager.Models;
using System.Timers;
using System;
using System.Diagnostics;
using System.Threading;

namespace TaskManager.ViewModels
{
    public class ActiveTaskViewModel : Screen
    {
        public string ActiveTaskTextBlock      { get; set; }
        public string DescriptionTextBlock     { get; set; }
        public string TimerActiveTaskTextBlock { get; set; }

        public ActiveTaskViewModel(Task task, FakeData context, string projectName)
        {
            this.projectName = projectName;
            this.context = context;
            stopwatch.Start();
            activeTask = task;
            ActiveTaskTextBlock = $"{task.TaskName}, Priorytet: {task.Priority}";
            DescriptionTextBlock = task.Description;
            TimerActiveTaskTextBlock = stopwatch.Elapsed.ToString();
            NotifyOfPropertyChange(() => TimerActiveTaskTextBlock);
        }

        public void EndTaskButton()
        {
            context.EndTask(activeTask, projectName);
            TryClose();
        }

        public void CancelTaskButton() => TryClose();

        private string    projectName;
        private FakeData  context;
        private Stopwatch stopwatch = new Stopwatch();
        private Task      activeTask;
    }
}
