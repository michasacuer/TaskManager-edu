using System.Linq;
using TaskManager.Models;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Services
{
    static class Validation 
    {
        static public bool IsLoginValid(string login, string password, FakeData context) => context.GetUsers().Any(u => u.Login == login);
        static public bool IsLoginExist(string login, FakeData context) => context.GetUsers().Any(u => u.Login == login);
        static public bool IsEmailExist(string email, FakeData context) => context.GetUsers().Any(u => u.Email == email);
        static public bool IsStringHaveSpaces(string text) => text.Contains(" ");

        static public bool IsEmailValid(string email)
        {
            var validator = new EmailAddressAttribute();
            return validator.IsValid(email);
        }
    }
}
