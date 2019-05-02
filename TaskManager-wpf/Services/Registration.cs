namespace TaskManager.WPF.Services
{
    using System;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public static class Registration
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
            else if (Validation.IsStringHaveSpaces(userToCheck.UserName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Login!");
            }
            else if (Validation.IsLoginExist(userToCheck.UserName, context))
            {
                throw new ArgumentException("Podany login jest już w bazie!");
            }
            else if (!Validation.IsEmailValid(userToCheck.Email))
            {
                throw new ArgumentException("Błędny adres Email!");
            }
            else if (Validation.IsEmailExist(userToCheck.Email, context))
            {
                throw new ArgumentException("Podany Email jest już w bazie!");
            }
            else if (Validation.IsStringHaveSpaces(userToCheck.LastName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Nazwisko!");
            }
        }
    }
}
