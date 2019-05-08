﻿namespace TaskManager.WPF.Services.FormsValidation
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public static class RegistrationForm
    {
        public static ValidationResult IsValid(
            RegistrationBindingModel accountForm,
            FakeData context,
            bool isManager,
            bool isDeveloper,
            bool isViewer)
        {
            var result = SetRole(accountForm, isManager, isDeveloper, isViewer);

            if (!result.IsValid)
            {
                return result;
            }

            if (accountForm.UserName == null || accountForm.FirstName == null ||
                accountForm.LastName == null || accountForm.Email == null)
            {
                result.IsValid = false;
                result.Message = "Wypełnij wszystkie pola!";

                return result;
            }
            else if (IsStringHaveSpaces(accountForm.UserName))
            {
                result.IsValid = false;
                result.Message = "Niedozwolone znaki w polu Login!";

                return result;
            }
            else if (IsLoginExist(accountForm.UserName, context))
            {
                result.IsValid = false;
                result.Message = "Podany login jest już w bazie!";

                return result;
            }
            else if (!IsEmailValid(accountForm.Email))
            {
                result.IsValid = false;
                result.Message = "Błędny adres Email!";

                return result;
            }
            else if (IsEmailExist(accountForm.Email, context))
            {
                result.IsValid = false;
                result.Message = "Podany Email jest już w bazie!";

                return result;
            }
            else if (IsStringHaveSpaces(accountForm.LastName))
            {
                result.IsValid = false;
                result.Message = "Niedozwolone znaki w polu Nazwisko!";

                return result;
            }

            result.Message = "Zarejestrowano pomyślnie!";

            return result;
        }

        private static ValidationResult SetRole(RegistrationBindingModel accountForm, bool isManager, bool isDeveloper, bool isViewer)
        {
            var result = new ValidationResult();

            if (!isManager && !isDeveloper && !isViewer)
            {
                result.IsValid = false;
                result.Message = "Wybierz stanowisko!";

                return result;
            }

            accountForm.Role = isManager ?
                 Role.Manager : isDeveloper ?
                 Role.Developer : isViewer ?
                 Role.Viewer : Role.Viewer;

            return result;
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
