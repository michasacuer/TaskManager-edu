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

            result.Message = Succes.Login;

            return result;
        }
    }
}
