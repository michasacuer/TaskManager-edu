namespace TaskManager.WPF.Services.FormsValidation
{
    using TaskManager.WPF.Models;
    using TaskManager.WPF.ViewModels;

    public static class NewProjectForm
    {
        public static ValidationResult IsValid(AddNewProjectViewModel vm)
        {
            var result = new ValidationResult();

            if (!LoggedUser.Instance.HavePermissionToAddTask())
            {
                result.Message = "Brak uprawnień! Zgłoś się do administratora!";
                result.IsValid = false;

                return result;
            }

            if (vm.ProjectNameTextBox == null)
            {
                result.Message = "Wypełnij wszystkie pola";
                result.IsValid = false;

                return result;
            }

            result.IsValid = true;

            return result;
        }
    }
}
