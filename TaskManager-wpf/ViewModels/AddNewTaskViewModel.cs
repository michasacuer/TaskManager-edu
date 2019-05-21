namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class AddNewTaskViewModel : Screen
    {
        public BindableCollection<string> ProjectsList { get; set; }

        public string SelectedProjectsList { get; set; }

        public string DescriptionTextBox { get; set; }

        public string TaskNameTextBox { get; set; }

        public bool LowPriorityButton { get; set; }

        public bool MediumPriorityButton { get; set; }

        public bool HighPriorityButton { get; set; }

        public Priority Priority { get; set; }

        public AddNewTaskViewModel(FakeData context, LoggedUser loggedUser)
        {
            this.context = context;
            this.loggedUser = loggedUser;
            this.ProjectsList = context.GetProjectsName();
        }

        public void AcceptButton()
        {
            if(!this.loggedUser.HavePermissionToAddTask())
            {
                Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
                return;
            }

            if (!NewTask.ProjectSelected(this.SelectedProjectsList))
            {
                Show.ErrorBox("Wybierz projekt!");
                return;
            }

            try
            {
                this.Priority = NewTask.SetPriority(this.LowPriorityButton, this.MediumPriorityButton, this.HighPriorityButton);
            }
            catch
            {
                Show.ErrorBox("Wybierz Priorytet!");
                return;
            }

            Task taskToCheck = new Task { Name = this.TaskNameTextBox, Priority = this.Priority, Description = this.DescriptionTextBox };
            (bool isValid, string alert) = NewTask.IsValid(taskToCheck);

            if (isValid)
            {
                this.context.AddTaskToProject(taskToCheck, this.SelectedProjectsList);
                Show.SuccesBox(alert + $" do projektu {this.SelectedProjectsList}!");
                this.TryClose();
            }
            else
            {
                Show.ErrorBox(alert);
            }
        }

        public void CancelButton() => this.TryClose();

        private FakeData context;
        private LoggedUser loggedUser;
    }
}
