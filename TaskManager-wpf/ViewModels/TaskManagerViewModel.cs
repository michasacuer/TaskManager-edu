namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.WPF.Models;

    internal class TaskManagerViewModel : Screen
    {
        public TaskManagerViewModel(FakeData context, LoggedUser loggedUser, Repository repository)
        {
            this.Projects = repository.Projects;

            this.context = context;
            this.loggedUser = loggedUser;
            this.ProjectsList = new BindableCollection<string>();

            foreach (var project in this.Projects)
            {
                this.ProjectsList.Add(project.Name);
            }
        }

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
                    this.tasks = this.Projects.First().Tasks;
                    foreach (TaskManager.Models.Task task in this.tasks)
                    {
                        this.TasksList.Add(task.Name + " - " + task.Priority.ToString());
                        this.NotifyOfPropertyChange(() => this.TasksList);
                    }
                }
                catch (ArgumentNullException)
                {
                    Show.ErrorBox($"Projekt o nazwie {this.selectedProjectList} nie ma tasków!");
                }
            }
        }

        private IEnumerable<TaskManager.Models.Project> Projects { get; set; }

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
        private IEnumerable<TaskManager.Models.Task> tasks;
        private string selectedProjectList;
    }
}
