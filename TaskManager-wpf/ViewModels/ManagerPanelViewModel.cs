namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class ManagerPanelViewModel : Conductor<IScreen>.Collection.OneActive
    {
        public ManagerPanelViewModel()
        {
            this.Projects = Repository.Instance.Projects;
            this.ProjectsList = new BindableCollection<string>();
            foreach (var project in this.Projects)
            {
                this.ProjectsList.Add(project.Name);
            }

            this.Items.Add(new ProjectsDataGridViewModel { DisplayName = "Projekty" });
            this.Items.Add(new TasksDataGridViewModel { DisplayName = "Zadania" });
            this.Items.Add(new EndedTasksDataGridViewModel { DisplayName = "Skończone zadania" });
        }

        public BindableCollection<string> ProjectsList { get; set; }

        public string SelectedProjectsList { get; set; }

        public IEnumerable<Project> Projects { get; set; }

        public void GeneratePdfButton()
        {
            if (this.SelectedProjectsList == null)
            {
                Show.ErrorBox("Wybierz projekt!");
            }

            //todo
        }

        public void ExitButton() => this.TryCloseAsync();
    }
}
