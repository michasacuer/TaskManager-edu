namespace TaskManager.WPF.Services.FormsValidation
{
    using System;
    using System.Linq;
    using TaskManager.WPF.Models;

    public static class LoginForm
    {
        public static bool IsValid(string login, string password, FakeData context)
        {
            bool isValid = context.GetUsers().Any(u => u.Login == login) ? true : throw new ArgumentException("Błędny login!");
            return isValid;
        }
    }
}
