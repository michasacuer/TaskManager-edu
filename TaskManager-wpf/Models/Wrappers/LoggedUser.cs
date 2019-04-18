namespace TaskManager.Models
{
    using TaskManager.Enums;

    public class LoggedUser
    {
        public void LoginUserToApp(User user) => this.user = user;

        public User GetInstance() => this.user;

        public string GetFullName() => $"{this.user.FirstName} {this.user.LastName}";

        public string GetPosition() => this.user.Position.ToString();

        public void Logout() => this.user = null;

        public bool HavePermissionToTakeTask()
            => this.user.Position == Position.Manager || this.user.Position == Position.Developer;

        public bool HavePermissionToAddTask() => this.user.Position == Position.Manager;

        private User user { get; set; }
    }
}
