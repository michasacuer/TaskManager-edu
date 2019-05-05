namespace TaskManager.WPF.Services.FormsValidation
{
    using TaskManager.WPF.Exceptions;
    using TaskManager.WPF.Models;

    public static class LoginForm
    {
        public static bool IsValid(string login, string password, FakeData context)
        {
            bool isValid = true;

            if (login == null || password == null)
            {
                throw new FormValidationException("Wypełnij wszystkie pola!");
            }
            else if (login.Contains(" ") || password.Contains(" "))
            {
                throw new FormValidationException("Niedozwolone znaki w formularzu!");
            }

            return isValid;
        }
    }
}
