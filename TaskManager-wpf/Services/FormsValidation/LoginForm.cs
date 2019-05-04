namespace TaskManager.WPF.Services.FormsValidation
{
    using System;
    using TaskManager.WPF.Models;

    public static class LoginForm
    {
        public static bool IsValid(string login, string password, FakeData context)
        {
            bool isValid = true;

            if (login.Contains(" ") || password.Contains(" "))
            {
                throw new ArgumentException("Niedozwolone znaki w formularzu!");
            }

            return isValid;
        }
    }
}
