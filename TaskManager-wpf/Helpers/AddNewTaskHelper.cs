namespace TaskManager.WPF.Helpers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskManager.WPF.Services;
    using TaskManager.WPF.Services.FormsValidation;
    using TaskManager.WPF.ViewModels;

    public class AddNewTaskHelper
    {
        public async Task<ValidationResult> AddTaskToDatabase(AddNewTaskViewModel vm)
        {
            var validationResult = NewTaskForm.IsValid(vm);

            if (validationResult.IsValid)
            {
                int? storyPoints = null;

                try
                {
                    if (vm.TaskNameTextBox.Contains(","))
                    {
                        var substring = vm.TaskNameTextBox.Substring(vm.TaskNameTextBox.IndexOf(",") + 1);
                        storyPoints = Convert.ToInt32(substring.Replace(" ", string.Empty));
                        vm.TaskNameTextBox = vm.TaskNameTextBox.Substring(0, vm.TaskNameTextBox.IndexOf(","));
                    }
                }
                catch (FormatException)
                {
                    validationResult.Message = "SP podajemy po przecinku jako liczba!";
                    validationResult.IsValid = false;

                    return validationResult;
                }

                var newTask = new TaskManager.Models.Task
                {
                    Name = vm.TaskNameTextBox,
                    Description = vm.DescriptionTextBox,
                    ProjectId = vm.Repository.Projects.Single(p => p.Name == vm.SelectedProjectsList).Id,
                    StoryPoints = storyPoints
                };

                var httpDataService = new HttpDataService();

                var taskFromResponse = await httpDataService.Post(newTask);

                vm.Repository.FetchAll();

                validationResult.Message = "Task dodano pomyślnie!";
            }

            return validationResult;
        }
    }
}
