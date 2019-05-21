namespace TaskManager.WPF.Services.FormsValidation
{
    using TaskManager.WPF.Models.BindingModels;
    using TaskManager.WPF.Strings;

    public static class LoginForm
    {
        public static ValidationResult IsValid(LoginBindingModel loginForm)
        {
            var result = new ValidationResult();
            result.IsValid = true;

            result.Message = Succes.Login;

            if (loginForm.UserName == null || loginForm.Password == null)
            {
                result.IsValid = false;
                result.Message = Error.FormEmpty;
            }
            else if (loginForm.UserName.Contains(" ") || loginForm.Password.Contains(" "))
            {
                result.IsValid = false;
                result.Message = Error.UnallowedChars;
            }

            return result;
        }
    }
}
