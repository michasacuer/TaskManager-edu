namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class TaskManagerViewModel : Screen
    {
        private readonly MainWindowViewModel vm;

        private string selectedProjectList;

        public TaskManagerViewModel(MainWindowViewModel vm)
        {
            this.vm = vm;

            this.Projects = Repository.Instance.Projects;
            this.ProjectsList = new BindableCollection<string>();

            foreach (var project in this.Projects)
            {
                this.ProjectsList.Add(project.Name);
            }

            this.IsAcceptButtonEnabled = !LoggedUser.Instance.GetUserTask().IsTaskTakenByUser();
            this.NotifyOfPropertyChange(() => this.IsAcceptButtonEnabled);
        }

        public bool IsAcceptButtonEnabled { get; set; }

        public BindableCollection<string> ProjectsList { get; set; }

        public BindableCollection<string> TasksList { get; set; }

        public string SelectedTasksList { get; set; }

        public string SelectedProjectsList
        {
            get => this.selectedProjectList;
            set
            {
                this.selectedProjectList = value;
                var helper = new TaskManagerHelper();

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
            if (!LoggedUser.Instance.HavePermissionToTakeTask())
            {
                Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
                return;
            }

            if (this.SelectedTasksList == null)
            {
                Show.ErrorBox("Wybierz zadanie!");
                return;
            }

            var helper = new TaskManagerHelper();
            var taskToActivate = await helper.GetTaskToActivate(LoggedUser.Instance, this.SelectedTasksList, this.SelectedProjectsList);

            if (taskToActivate != null)
            {
                LoggedUser.Instance.AttachTaskToUser(taskToActivate);

                await this.TryCloseAsync();

                this.vm.IsActiveTaskButtonVisible = Visibility.Visible;
                this.vm.NotifyOfPropertyChange(() => this.vm.IsActiveTaskButtonVisible);
            }
            else
            {
                await this.TryCloseAsync();
            }
        }

        public void CancelButton() => this.TryCloseAsync();
    }
}
