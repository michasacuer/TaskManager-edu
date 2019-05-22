namespace TaskManager.WPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models.Enums;
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class AddNewTaskViewModel : Screen
    {
        public AddNewTaskViewModel(LoggedUser loggedUser, Repository repository)
        {
            this.Projects = repository.Projects;

            this.Repository = repository;

            this.LoggedUser = loggedUser;

            this.ProjectsList = new BindableCollection<string>();

            foreach (var project in this.Projects)
            {
                this.ProjectsList.Add(project.Name);
            }
        }

        public BindableCollection<string> ProjectsList { get; set; }

        public string SelectedProjectsList { get; set; }

        public string DescriptionTextBox { get; set; }

        public string TaskNameTextBox { get; set; }

        public bool LowPriorityButton { get; set; }

        public bool MediumPriorityButton { get; set; }

        public bool HighPriorityButton { get; set; }

        public int? StoryPoints { get; set; }

        public Priority Priority { get; set; }

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public LoggedUser LoggedUser { get; set; }

        public Repository Repository { get; set; }

        public async void AcceptButton()
        {
            var helper = new AddNewTaskHelper();

            try
            {
                var validationResult = await helper.AddTaskToDatabase(this);

                if (validationResult.IsValid)
                {
                    this.TryClose();
                    Show.SuccesBox(validationResult.Message);
                }
                else
                {
                    Show.ErrorBox(validationResult.Message);
                }
            }
            catch (AddNewTaskException exception)
            {

            }


            //if (!this.loggedUser.HavePermissionToAddTask())
            //{
            //    Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
            //    return;
            //}
            //
            //if (!NewTask.ProjectSelected(this.SelectedProjectsList))
            //{
            //    Show.ErrorBox("Wybierz projekt!");
            //    return;
            //}
            //
            //try
            //{
            //    this.Priority = NewTask.SetPriority(this.LowPriorityButton, this.MediumPriorityButton, this.HighPriorityButton);
            //}
            //catch
            //{
            //    Show.ErrorBox("Wybierz Priorytet!");
            //    return;
            //}
            //
            //TaskManager.Models.Task taskToCheck = new TaskManager.Models.Task
            //{
            //    Name = this.TaskNameTextBox,
            //    Priority = this.Priority,
            //    Description = this.DescriptionTextBox
            //};
            //
            //(bool isValid, string alert) = NewTask.IsValid(taskToCheck);
            //
            //if (isValid)
            //{
            //    //this.context.AddTaskToProject(taskToCheck, this.SelectedProjectsList);
            //
            //    Show.SuccesBox(alert + $" do projektu {this.SelectedProjectsList}!");
            //    this.TryClose();
            //}
            //else
            //{
            //    Show.ErrorBox(alert);
            //}
        }

        public void CancelButton() => this.TryClose();
    }
}