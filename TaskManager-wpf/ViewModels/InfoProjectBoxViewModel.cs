namespace TaskManager.WPF.ViewModels
{
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class InfoProjectBoxViewModel : Screen
    {
        private readonly Project editedProject;

        public InfoProjectBoxViewModel(Project project)
        {
            this.editedProject = project;
            this.NavbarProjectName = project.Name;
            this.IdTextBox = project.Id.ToString();
            this.NameTextBox = project.Name;
            this.TagTextBox = project.Tag;
            this.DescriptionTextBox = project.Description;
        }

        public string NavbarProjectName { get; set; }

        public string IdTextBox { get; set; }

        public string NameTextBox { get; set; }

        public string TagTextBox { get; set; }

        public string DescriptionTextBox { get; set; }

        public void SaveButton()
        {
            if (LoggedUser.Instance.HavePermissionToDelete())
            {
                this.editedProject.Name = this.NameTextBox;
                this.editedProject.Tag = this.TagTextBox;
                this.editedProject.Description = this.DescriptionTextBox;

                var helper = new InfoProjectHelper();
                helper.EditProject(this.editedProject);

                Show.SuccesBox("Pomyslnie edytowano projekt.");
                this.TryCloseAsync();
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do edytowania projektów!");
            }
        }

        public void CancelButton()
        {
            this.TryCloseAsync();
        }
    }
}
