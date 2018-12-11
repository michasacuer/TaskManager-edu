using System;
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
                try
                {
                    tasks = context.GetProjectsTasks(SelectedProjectsList);
                    foreach (Task task in tasks)
                    {
                        TasksList.Add(task.TaskName + " - " + task.Priority.ToString());
                        NotifyOfPropertyChange(() => TasksList);
                    }
                }
                catch (ArgumentNullException ex) { Show.ErrorBox($"Projekt o nazwie {selectedProjectList} nie ma tasków!"); }
            }
        }

        public TaskManagerViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
            ProjectsList = context.GetProjectsName();
        }

        public void AcceptButton()
        {
            if (!loggedUser.HavePermissionToTakeTask())
            {
                Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
                return;
            }

            if(SelectedTasksList == null)
            {
                Show.ErrorBox("Wybierz zadanie!");
                return;
            }

            TryClose();
            Show.ActiveTaskBox(SelectedTasksList, SelectedProjectsList, context);
        }

        public void CancelButton() => TryClose();

        private LoggedUser loggedUser;
        private FakeData context;
        private List<Task> tasks;
        private string selectedProjectList;
    }
}
