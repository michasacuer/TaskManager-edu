namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models.Enums;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

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

        public Priority Priority { get; set; }

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public LoggedUser LoggedUser { get; set; }

        public Repository Repository { get; set; }

        public async void AcceptButton()
        {
            var helper = new AddNewTaskHelper();

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

        public void CancelButton() => this.TryClose();
    }
}