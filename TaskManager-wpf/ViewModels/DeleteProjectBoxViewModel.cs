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
            this.DeleteName = project.Name;
        }

        public string DeleteName { get; set; }

        public void YesButton()
        {
            var helper = new DeleteFromDatabaseHelper();
            helper.DeleteProject(this.projectToDelete);

            this.TryCloseAsync();
        }

        public void NoButton()
        {
            this.TryCloseAsync();
        }
    }
}
