namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class InfoTaskBoxViewModel : Screen
    {
        private readonly Task editedTask;

        public InfoTaskBoxViewModel(Task task)
        {
            this.editedTask = task;
            this.NavbarTaskName = task.Name;
            this.IdTextBox = task.Id.ToString();
            this.NameTextBox = task.Name;
            this.PriorityTextBox = task.Priority.ToString();
            this.StoryPointsTextBox = task.StoryPoints.ToString();
            this.ProjectIdTextBox = task.ProjectId.ToString();
            this.StartDateTextBox = task.StartTime.ToString();
            this.DescriptionTextBox = task.Description;
        }

        public string NavbarTaskName { get; set; }

        public string IdTextBox { get; set; }

        public string NameTextBox { get; set; }

        public string PriorityTextBox { get; set; }

        public string StoryPointsTextBox { get; set; }

        public string ProjectIdTextBox { get; set; }

        public string StartDateTextBox { get; set; }

        public string DescriptionTextBox { get; set; }

        public void SaveButton()
        {
            if (LoggedUser.Instance.HavePermissionToDelete())
            {
                this.editedTask.Name = this.NameTextBox;
                this.editedTask.Description = this.DescriptionTextBox;

                var helper = new InfoHelper();
                helper.EditTask(this.editedTask);

                Show.SuccesBox("Pomyslnie edytowano zadanie.");
                this.TryCloseAsync();
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do edytowania zadań!");
            }
        }

        public void CancelButton()
        {
            this.TryCloseAsync();
        }
    }
}
