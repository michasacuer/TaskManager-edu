namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class TaskManagerViewModel : Screen
    {
        public TaskManagerViewModel(LoggedUser loggedUser, Repository repository)
        {
            this.Projects = repository.Projects;

            this.repository = repository;

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
                var helper = new TaskManagerHelper(this.repository);

                try
                {
                    this.TasksList = helper.PopulateTasksList(this.SelectedProjectsList);
                    this.NotifyOfPropertyChange(() => this.TasksList);
                }
                catch (ArgumentNullException)
                {
                    Show.ErrorBox($"Projekt o nazwie {this.selectedProjectList} nie ma tasków!");
                }
            }
        }

        private IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public async void AcceptButton()
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

            var helper = new TaskManagerHelper(this.repository);
            this.loggedUser.AttachTaskToUser(await helper.GetTaskToActivate(this.SelectedTasksList, this.SelectedProjectsList));

            this.TryClose();

            Show.ActiveTaskBox(this.loggedUser.GetUserTask());
        }

        public void CancelButton() => this.TryClose();

        private LoggedUser loggedUser;

        private List<TaskManager.Models.Task> tasks;

        private string selectedProjectList;

        private Repository repository;
    }
}
