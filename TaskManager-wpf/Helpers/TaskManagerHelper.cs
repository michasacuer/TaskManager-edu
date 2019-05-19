namespace TaskManager.WPF.Helpers
{
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    public class TaskManagerHelper
    {
        public BindableCollection<string> PopulateTasksList(Repository repository, string selectedProjectsList)
        {
            var tasksList = new BindableCollection<string>();

            var tasks = repository.Projects.Single(p => p.Name == selectedProjectsList).Tasks;
            foreach (var task in tasks)
            {
                tasksList.Add(task.Name + " - " + task.Priority.ToString());
            }

            return tasksList;
        }
    }
}
