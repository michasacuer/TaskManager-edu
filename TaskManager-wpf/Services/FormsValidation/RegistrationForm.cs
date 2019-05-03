namespace TaskManager.WPF.Services
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public static class RegistrationForm
    {
        public static Role SetJob(bool isManager, bool isDeveloper, bool isViewer) =>
            isManager ? Role.Manager :
            isDeveloper ? Role.Developer :
            isViewer ? Role.Viewer : throw new ArgumentException("Wybierz stanowisko!");

        public static void IsValid(RegistrationBindingModel userToCheck, FakeData context)
        {
            if (userToCheck.UserName == null || userToCheck.FirstName == null ||
                userToCheck.LastName == null || userToCheck.Email == null)
            {
                throw new ArgumentException("Wypełnij wszystkie pola!");
            }
            else if (IsStringHaveSpaces(userToCheck.UserName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Login!");
            }
            else if (IsLoginExist(userToCheck.UserName, context))
            {
                throw new ArgumentException("Podany login jest już w bazie!");
            }
            else if (!IsEmailValid(userToCheck.Email))
            {
                throw new ArgumentException("Błędny adres Email!");
            }
            else if (IsEmailExist(userToCheck.Email, context))
            {
                throw new ArgumentException("Podany Email jest już w bazie!");
            }
            else if (IsStringHaveSpaces(userToCheck.LastName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Nazwisko!");
            }
        }

        private static bool IsLoginValid(string login, string password, FakeData context)
            => context.GetUsers().Any(u => u.Login == login);

        private static bool IsLoginExist(string login, FakeData context) => context.GetUsers().Any(u => u.Login == login);

        private static bool IsEmailExist(string email, FakeData context) => context.GetUsers().Any(u => u.Email == email);

        private static bool IsStringHaveSpaces(string text) => text.Contains(" ");

        private static bool IsEmailValid(string email)
        {
            var validator = new EmailAddressAttribute();
            return validator.IsValid(email);
        }
    }
}
