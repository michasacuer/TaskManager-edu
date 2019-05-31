namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;

    public class DeleteProjectBoxViewModel : Screen
    {
        private readonly Project projectToDelete;

        public DeleteProjectBoxViewModel(Project project)
        {
            this.projectToDelete = project;
            this.DeleteName = "Usunąć projekt " + project.Name + "?";
        }

        public string DeleteName { get; set; }

        public void Yes()
        {
            var helper = new DeleteProjectHelper();
            helper.DeleteProjectFromDatabase(this.projectToDelete);

            this.TryCloseAsync(true);
        }

        public void No()
        {
            this.TryCloseAsync(false);
        }
    }
}
