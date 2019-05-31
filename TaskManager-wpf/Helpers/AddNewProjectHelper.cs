﻿namespace TaskManager.WPF.Helpers
{
    using System.Threading.Tasks;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class AddNewProjectHelper
    {
        public async Task<ValidationResult> AddProjectToDatabase(AddNewProjectViewModel vm)
        {
            var validationResult = NewProjectForm.IsValid(vm);

            if (validationResult.IsValid)
            {
                var newProject = new TaskManager.Models.Project
                {
                    Name = vm.ProjectNameTextBox,
                    Description = vm.DescriptionTextBox
                };

                var httpDataService = new HttpDataService();

                var projectFromResponse = await httpDataService.Post(newProject);

                Repository.Instance.FetchAll();

                validationResult.Message = "Projekt dodano pomyślnie!";
            }

            return validationResult;
        }
    }
}
