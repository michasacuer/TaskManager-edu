namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;

    public class ProjectsDataGridViewModel : Screen
    {
        public ProjectsDataGridViewModel()
        {
            this.Projects = (List<Project>)Repository.Instance.Projects;
        }

        public List<Project> Projects { get; set; }

        public void InfoButton(Project project)
        {
            Show.InfoProjectBox(project);

            this.Projects = (List<Project>)Repository.Instance.Projects;
            this.NotifyOfPropertyChange(() => this.Projects);
        }

        public void DeleteButton(TaskManager.Models.Project project)
        {
            if (LoggedUser.Instance.IsManager())
            {
                Show.DeleteProjectBox(project);

                this.Projects = (List<Project>)Repository.Instance.Projects;
                this.NotifyOfPropertyChange(() => this.Projects);
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do usuwania zadań!");
            }
        }
    }
}
