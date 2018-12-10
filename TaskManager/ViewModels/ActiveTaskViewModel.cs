using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    public class ActiveTaskViewModel : Screen
    {
        public string ActiveTaskTextBlock { get; set; }
        public string DescriptionTextBlock { get; set; }

        public ActiveTaskViewModel(Task task)
        {
            activeTask = task;
            ActiveTaskTextBlock = $"{task.TaskName}, Priorytet: {task.Priority}";
            DescriptionTextBlock = task.Description;
        }

        public void CancelTaskButton() => TryClose();

        private Task activeTask;
    }
}
