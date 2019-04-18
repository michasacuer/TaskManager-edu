namespace TaskManager.WPF.Services
{
    using TaskManager.WPF.Enums;
    using TaskManager.WPF.Models;

    public static class Registration
    {
        public static Position SetJob(bool isManager, bool isDeveloper, bool isViewer) => 
            isManager ? Position.Manager :
            isDeveloper ? Position.Developer :
            isViewer ? Position.Viewer : throw new System.ArgumentNullException();

        public static(bool, string) IsValid(User userToCheck, FakeData context)
        {
            bool isUserOk = true;
            string alert = "Zarejestrowano pomyślnie!";

            if (userToCheck.Login == null || userToCheck.FirstName == null ||
                userToCheck.LastName == null || userToCheck.Email == null)
            {
                isUserOk = false;
                alert = "Wypełnij wszystkie wymagane pola!";
            }
            else if (Validation.IsStringHaveSpaces(userToCheck.Login))
            {
                isUserOk = false;
                alert = "Niedozwolone znaki w polu Login!";
            }
            else if (Validation.IsLoginExist(userToCheck.Login, context))
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
