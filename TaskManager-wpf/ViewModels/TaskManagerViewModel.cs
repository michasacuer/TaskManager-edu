namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    internal class TaskManagerViewModel : Screen
    {
        public BindableCollection<string> ProjectsList { get; set; }

        public BindableCollection<string> TasksList { get; set; }

        public string SelectedTasksList { get; set; }

        public string SelectedProjectsList
        {
            get => this.selectedProjectList;
            set
            {
                this.selectedProjectList = value;
                this.TasksList = new BindableCollection<string>();
                try
                {
                    this.tasks = this.context.GetProjectsTasks(this.SelectedProjectsList);
                    foreach (Task task in this.tasks)
                    {
                        this.TasksList.Add(task.TaskName + " - " + task.Priority.ToString());
                        this.NotifyOfPropertyChange(() => this.TasksList);
                    }
                }
                catch (ArgumentNullException ex)
                {
                    Show.ErrorBox($"Projekt o nazwie {this.selectedProjectList} nie ma tasków!");
                }
            }
        }

        public TaskManagerViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
            this.ProjectsList = context.GetProjectsName();
        }

        public void AcceptButton()
        {
            if (!this.loggedUser.HavePermissionToTakeTask())
            {
                Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
                return;
            }

            if (this.SelectedTasksList == null)
            {
                Show.ErrorBox("Wybierz zadanie!");
                return;
            }

            this.TryClose();
            Show.ActiveTaskBox(this.SelectedTasksList, this.SelectedProjectsList, this.context);
        }

        public void CancelButton() => this.TryClose();

        private LoggedUser loggedUser;
        private FakeData context;
        private List<Task> tasks;
        private string selectedProjectList;
    }
}
