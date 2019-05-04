﻿namespace TaskManager.WPF.Services.FormsValidation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public static class RegistrationForm
    {
        public static void SetJob(RegistrationBindingModel accountForm, bool isManager, bool isDeveloper, bool isViewer)
            => accountForm.Role = isManager ?
               Role.Manager : isDeveloper ?
               Role.Developer : isViewer ?
               Role.Viewer : throw new ArgumentException("Wyrz stanowisko!");

        public static void IsValid(RegistrationBindingModel accountForm, FakeData context)
        {
            if (accountForm.UserName == null || accountForm.FirstName == null ||
                accountForm.LastName == null || accountForm.Email == null)
            {
                throw new ArgumentException("Wypełnij wszystkie pola!");
            }
            else if (IsStringHaveSpaces(accountForm.UserName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Login!");
            }
            else if (IsLoginExist(accountForm.UserName, context))
            {
                throw new ArgumentException("Podany login jest już w bazie!");
            }
            else if (!IsEmailValid(accountForm.Email))
            {
                throw new ArgumentException("Błędny adres Email!");
            }
            else if (IsEmailExist(accountForm.Email, context))
            {
                throw new ArgumentException("Podany Email jest już w bazie!");
            }
            else if (IsStringHaveSpaces(accountForm.LastName))
            {
                throw new ArgumentException("Niedozwolone znaki w polu Nazwisko!");
            }
        }

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