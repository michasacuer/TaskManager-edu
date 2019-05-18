namespace TaskManager.WPF.Models
{
    using TaskManager.WPF.Enums;

    public class LoggedUser
    {
        public void LoginUserToApp(User user) => this.user = user;

        public User GetInstance() => this.user;

        public string GetFullName() => $"{this.user.FirstName} {this.user.LastName}";

        public string GetPosition() => this.user.Role.ToString();

        public void Logout() => this.user = null;

        public bool HavePermissionToTakeTask()
            => this.user.Role == Role.Manager || this.user.Role == Role.Developer;

        public bool HavePermissionToAddTask() => this.user.Role == Role.Manager;

        private User user { get; set; }
    }
}
