namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;

    public class DeleteTaskBoxViewModel : Screen
    {
        private readonly Task editedTask;

        public DeleteTaskBoxViewModel(Task task)
        {
            this.editedTask = task;
            this.DeleteName = task.Name;
        }

        public string DeleteName { get; set; }

        public void YesButton()
        {
            var helper = new DeleteFromDatabaseHelper();
            helper.DeleteTask(this.editedTask);

            this.TryCloseAsync();
        }

        public void NoButton() => this.TryCloseAsync();
    }
}
