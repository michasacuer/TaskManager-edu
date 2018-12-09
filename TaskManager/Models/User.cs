using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(string login, string password, string firstName, string lastName, string email, bool admin)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IsAdmin = admin;
        }
    }
}
