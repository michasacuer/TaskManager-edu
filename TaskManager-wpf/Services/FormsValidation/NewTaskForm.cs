namespace TaskManager.WPF.Services.FormsValidation
{
    using System;
    using TaskManager.Models.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.ViewModels;

    public static class NewTaskForm
    {
        public static ValidationResult IsValid(AddNewTaskViewModel vm)
        {
            var result = new ValidationResult();

            if (!LoggedUser.Instance.IsManager())
            {
                result.Message = "Brak uprawnień! Zgłoś się do administratora!";
                result.IsValid = false;

                return result;
            }

            if (vm.SelectedProjectsList == null || vm.TaskNameTextBox == null)
            {
                result.Message = "Wypełnij wszystkie pola";
                result.IsValid = false;

                return result;
            }

            try
            {
                vm.Priority = SetPriority(vm.LowPriorityButton, vm.MediumPriorityButton, vm.HighPriorityButton);
            }
            catch (ArgumentNullException)
            {
                result.Message = "Wybierz Priorytet!";
                result.IsValid = false;

                return result;
            }

            result.IsValid = true;

            return result;
        }

        private static Priority SetPriority(bool isLow, bool isMedium, bool isHigh)
        {
            if (isLow)
            {
                return Priority.Low;
            }

            if (isMedium)
            {
                return Priority.Medium;
            }

            if (isHigh)
            {
                return Priority.High;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}