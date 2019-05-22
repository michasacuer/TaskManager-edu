namespace TaskManager.WPF.Helpers
{
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
                var newTask = new TaskManager.Models.Task
                {
                    Name = vm.TaskNameTextBox,
                    Description = vm.DescriptionTextBox,
                    ProjectId = vm.Repository.Projects.Single(p => p.Name == vm.SelectedProjectsList).Id
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
