namespace TaskManager.WPF.Services.FormsValidation
{
    using TaskManager.WPF.Models.BindingModels;

    public static class LoginForm
    {
        public static ValidationResult IsValid(LoginBindingModel loginForm)
        {
            var result = new ValidationResult();
            result.IsValid = true;

            if (loginForm.UserName == null || loginForm.Password == null)
            {
                result.IsValid = false;
                result.Message = "Wypełnij wszystkie pola!";
            }
            else if (loginForm.UserName.Contains(" ") || loginForm.Password.Contains(" "))
            {
                result.IsValid = false;
                result.Message = "Niedozwolone znaki w formularzu!";
            }

            result.Message = "Zalogowano pomyślnie!";

            return result;
        }
    }
}
