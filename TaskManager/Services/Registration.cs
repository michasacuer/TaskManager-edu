using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services
{
    static public class Registration
    {
        public static (bool, string) IsRegistrationValid(User userToCheck, FakeData context)
        {
            bool isUserOk = true;
            string alert = "Zarejestrowano pomyślnie!";

            if (userToCheck.Login == null || userToCheck.FirstName == null ||
                userToCheck.LastName == null || userToCheck.Email == null)
            {
                isUserOk = false;
                alert = "Wypełnij wszystkie wymagane pola!";
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


            return (isUserOk, alert);
        }
    }
}
