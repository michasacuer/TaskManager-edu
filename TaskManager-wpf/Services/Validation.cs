namespace TaskManager.Services
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TaskManager.Models;

    internal static class Validation 
    {
        public static bool IsLoginValid(string login, string password, FakeData context)
            => context.GetUsers().Any(u => u.Login == login);

        public static bool IsLoginExist(string login, FakeData context) => context.GetUsers().Any(u => u.Login == login);

        public static bool IsEmailExist(string email, FakeData context) => context.GetUsers().Any(u => u.Email == email);

        public static bool IsStringHaveSpaces(string text) => text.Contains(" ");

        public static bool IsEmailValid(string email)
        {
            var validator = new EmailAddressAttribute();
            return validator.IsValid(email);
            //test
        }
    }
}
