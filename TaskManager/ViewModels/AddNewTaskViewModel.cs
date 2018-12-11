using Caliburn.Micro;
using TaskManager.Models;
using TaskManager.Enums;
using TaskManager.Services;

namespace TaskManager.ViewModels
{
    class AddNewTaskViewModel : Screen
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
            ProjectsList = context.GetProjectsName();
        }

        public void AcceptButton()
        {
            if(!loggedUser.HavePermissionToAddTask())
            {
                Show.ErrorBox("Brak uprawnień! Zgłoś się do administratora.");
                return;
            }

            if (!NewTask.ProjectSelected(SelectedProjectsList))
            {
                Show.ErrorBox("Wybierz projekt!");
                return;
            }
            
            try { Priority = NewTask.SetPriority(LowPriorityButton, MediumPriorityButton, HighPriorityButton); }
            catch { Show.ErrorBox("Wybierz Priorytet!"); return; }

            Task taskToCheck = new Task(TaskNameTextBox, Priority, DescriptionTextBox);
            (bool isValid, string alert) = NewTask.IsValid(taskToCheck);

            if (isValid)
            {
                context.AddTaskToProject(taskToCheck, SelectedProjectsList);
                Show.SuccesBox(alert + $" do projektu {SelectedProjectsList}!");
                TryClose();
            }
            else
                Show.ErrorBox(alert);
        }

        public void CancelButton() => TryClose();

        FakeData context;
        LoggedUser loggedUser;
    }
}
