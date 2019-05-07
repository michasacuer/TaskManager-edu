namespace TaskManager.WPF.Services.FormsValidation
{
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models.BindingModels;

    public static class LoginForm
    {
        public static bool IsValid(LoginBindingModel loginForm)
        {
            bool isValid = true;

            if (loginForm.UserName == null || loginForm.Password == null)
            {
                throw new FormValidationException("Wypełnij wszystkie pola!");
            }
            else if (loginForm.UserName.Contains(" ") || loginForm.Password.Contains(" "))
            {
                throw new FormValidationException("Niedozwolone znaki w formularzu!");
            }

            return isValid;
        }
    }
}
