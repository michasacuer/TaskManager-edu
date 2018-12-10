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
        public string ActiveTaskTextBlock { get; set; }
        public string DescriptionTextBlock { get; set; }
        public string TimerActiveTaskTextBlock { get; set; }

        public ActiveTaskViewModel(Task task)
        {
            stopwatch.Start();
            activeTask = task;
            ActiveTaskTextBlock = $"{task.TaskName}, Priorytet: {task.Priority}";
            DescriptionTextBlock = task.Description;
            TimerActiveTaskTextBlock = stopwatch.Elapsed.ToString();
            NotifyOfPropertyChange(() => TimerActiveTaskTextBlock);
        }

        public void CancelTaskButton() => TryClose();

        private Stopwatch stopwatch = new Stopwatch();
        private Task activeTask;
    }
}
