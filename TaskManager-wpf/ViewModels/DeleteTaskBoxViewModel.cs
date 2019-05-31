namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.WPF.Helpers;

    public class DeleteTaskBoxViewModel : Screen
    {
        private readonly TaskManager.Models.Task taskToDelete;

        public DeleteTaskBoxViewModel(TaskManager.Models.Task task)
        {
            this.taskToDelete = task;
            this.DeleteName = "Usunąć zadanie " + task.Name + "?";
        }

        public string DeleteName { get; set; }

        public void Yes()
        {
            var helper = new DeleteTaskHelper();
            helper.DeleteTaskFromDatabase(this.taskToDelete);

            this.TryCloseAsync(true);
        }

        public void No()
        {
            this.TryCloseAsync(false);
        }
    }
}
