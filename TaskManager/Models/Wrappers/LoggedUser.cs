using TaskManager.Enums;

namespace TaskManager.Models
{
    public class LoggedUser
    {
        public void LoginUserToApp(User user) => this.user = user;
        public User GetInstance() => user;
        public string GetFullName() => $"{user.FirstName} {user.LastName}";
        public string GetPosition() => user.Position.ToString();

        private User user { get; set; }
    }
}
