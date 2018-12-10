using Caliburn.Micro;
using TaskManager.Models;
using System.Collections.Generic;
using TaskManager.Enums;
using TaskManager.Services;
using TaskManager.Models;

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
            if (!NewTask.ProjectSelected(SelectedProjectsList))
            {
                manager.ShowDialog(new ErrorBoxViewModel("Wybierz Projekt!"), null, null);
                return;
            }
            
            try { Priority = NewTask.SetPriority(LowPriorityButton, MediumPriorityButton, HighPriorityButton); }
            catch { manager.ShowDialog(new ErrorBoxViewModel("Wybierz Priorytet!"), null, null); return; }

            Task taskToCheck = new Task(TaskNameTextBox, Priority, DescriptionTextBox);
            (bool isValid, string alert) = NewTask.IsValid(taskToCheck);

            if (isValid)
            {
                context.AddTaskToProject(taskToCheck, SelectedProjectsList);
                manager.ShowDialog(new SuccesBoxViewModel(alert), null, null);
                TryClose();
            }
            else
                manager.ShowDialog(new ErrorBoxViewModel(alert), null, null);
        }

        public void CancelButton() => TryClose();

        private IWindowManager manager = new WindowManager();
        FakeData context;
        LoggedUser loggedUser;
    }
}
