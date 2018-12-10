using TaskManager.Enums;
using TaskManager.Models;

namespace TaskManager.Services
{
    static public class Registration
    {
        public static Position SetJob(bool isManager, bool isDeveloper, bool isViewer) => 
            isManager == true ? Position.Manager : 
            isDeveloper == true ? Position.Developer : 
            isViewer == true ? Position.Viewer : throw new System.ArgumentNullException();


        public static (bool, string) IsValid(User userToCheck, FakeData context)
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
