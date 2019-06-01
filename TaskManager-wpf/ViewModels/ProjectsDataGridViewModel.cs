namespace TaskManager.WPF.ViewModels
{
    using System.Collections.Generic;
    using Caliburn.Micro;
    using TaskManager.Models;
    using TaskManager.WPF.Helpers;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;

    public class ProjectsDataGridViewModel : Screen
    {
        public ProjectsDataGridViewModel()
        {
            this.Projects = (List<TaskManager.Models.Project>)Repository.Instance.Projects;
        }

        public List<TaskManager.Models.Project> Projects { get; set; }

        public async void InfoButton(Project project)
        {
            Show.InfoProjectBox(project);

            await Repository.Instance.FetchAll();

            var httpDataService = new HttpDataService();
            var temp = await httpDataService.Get<Project>();
            this.Projects = (List<Project>)temp;

            this.NotifyOfPropertyChange(() => this.Projects);
        }

        public async void DeleteButton(TaskManager.Models.Project project)
        {
            if (LoggedUser.Instance.HavePermissionToDelete())
            {
                Show.DeleteProjectBox(project);

                await Repository.Instance.FetchAll();

                var httpDataService = new HttpDataService();
                var temp = await httpDataService.Get<Project>();
                this.Projects = (List<Project>)temp;

                this.NotifyOfPropertyChange(() => this.Projects);
            }
            else
            {
                Show.ErrorBox("Nie masz uprawnień do usuwania zadań!");
            }
        }
    }
}
