namespace TaskManager.WPF.Models
{
    using TaskManager.WPF.Enums;

    public class User
    {
        public string Login { get; private set; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Role Position { get; private set; }

        public User(string login, string password, string firstName, string lastName, string email, Role position)
        {
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Position = position;
        }
    }
}
