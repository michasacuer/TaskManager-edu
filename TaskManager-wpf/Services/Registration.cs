namespace TaskManager.WPF.Services
{
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;
    using TaskManager.WPF.Models.BindingModels;

    public static class Registration
    {
        public static Role SetJob(bool isManager, bool isDeveloper, bool isViewer) =>
            isManager ? Role.Manager :
            isDeveloper ? Role.Developer :
            isViewer ? Role.Viewer : throw new System.ArgumentNullException();

        public static(bool, string) IsValid(RegistrationBindingModel userToCheck, FakeData context)
        {
            bool isUserOk = true;
            string alert = "Zarejestrowano pomyślnie!";

            if (userToCheck.UserName == null || userToCheck.FirstName == null ||
                userToCheck.LastName == null || userToCheck.Email == null)
            {
                isUserOk = false;
                alert = "Wypełnij wszystkie wymagane pola!";
            }
            else if (Validation.IsStringHaveSpaces(userToCheck.UserName))
            {
                isUserOk = false;
                alert = "Niedozwolone znaki w polu Login!";
            }
            else if (Validation.IsLoginExist(userToCheck.UserName, context))
            {
                isUserOk = false;
                alert = "Podany login jest już w bazie!";
            }
            else if (!Validation.IsEmailValid(userToCheck.Email))
            {
                isUserOk = false;
                alert = "Błędny adres email!";
            }
            else if (Validation.IsEmailExist(userToCheck.Email, context))
            {
                isUserOk = false;
                alert = "Podany Email jest już w bazie!";
            }
            else if (Validation.IsStringHaveSpaces(userToCheck.LastName))
            {
                isUserOk = false;
                alert = "Niedozwolone znaki w polu Nazwisko!";
            }

            return (isUserOk, alert);
        }
    }
}
