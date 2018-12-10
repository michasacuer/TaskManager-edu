using TaskManager.Enums;

namespace TaskManager.Models
{
    public class LoggedUser
    {
        public void LoginUserToApp(User user) => this.user = user;
        public User GetInstance() => user;
        public string GetFullName() => $"{user.FirstName} {user.LastName}";
        public string GetPosition() => user.Position.ToString();
        //public (string, string) ResetName(string firstName, string LastName) =>  
        public void LogOut() => user = null;

        private User user { get; set; }
    }
}
