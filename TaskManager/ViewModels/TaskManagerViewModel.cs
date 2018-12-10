using System.Collections.Generic;
using Caliburn.Micro;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    class TaskManagerViewModel : Screen
    {
        public BindableCollection<string> ProjectsList { get; set; }
        public BindableCollection<string> TasksList { get; set; }
        public string SelectedTasksList { get; set; }
        public string SelectedProjectsList
        {
            get => selectedProjectList; 
            set
            {
                selectedProjectList = value;
                TasksList = new BindableCollection<string>();
                tasks = context.GetProjectsTasks(SelectedProjectsList);
                foreach (Task task in tasks)
                {
                    TasksList.Add(task.TaskName + " - " + task.Priority.ToString());
                    NotifyOfPropertyChange(() => TasksList);
                }
            }
        }

        public TaskManagerViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            ProjectsList = context.GetProjectsName();
        }

        public void AcceptButton()
        {
            if (!loggedUser.HavePermissionToTakeTask())
                manager.ShowWindow(new ErrorBoxViewModel("Brak uprawnień! Zgłoś się do administratora"), null, null);



        }

        public void CancelButton() => TryClose();

        IWindowManager manager = new WindowManager();
        private LoggedUser loggedUser;
        private FakeData context;
        private List<Task> tasks;
        private string selectedProjectList;
    }
}
