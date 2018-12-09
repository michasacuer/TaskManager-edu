using System.Linq;
using TaskManager.Models;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Services
{
    static class Validation 
    {
        static public bool IsLoginValid(string login, string password, FakeData context) 
            => context.GetUsers().Any(i => i.Login == login);

        static public bool IsLoginExist(string login, FakeData context)
            => context.GetUsers().Any(i => i.Login == login);

        static public bool IsEmailValid(string email)
        {
            var validator = new EmailAddressAttribute();
            return validator.IsValid(email);
        }

        static public bool IsEmailExist(string email, FakeData context)
            => context.GetUsers().Any(i => i.Email == email);
    }
}
