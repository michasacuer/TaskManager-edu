namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models.Enums;
    using TaskManager.WPF.Models;

    public class LoggedUser
    {
        private User User { get; set; }

        public void LoginUserToApp(User user) => this.User = user;

        public User GetInstance() => this.User;

        public string GetFullName() => $"{this.User.FirstName} {this.User.LastName}";

        public string GetPosition() => this.User.Role.ToString();

        public void Logout() => this.User = null;

        public bool HavePermissionToTakeTask()
            => this.User.Role == Role.Manager || this.User.Role == Role.Developer;

        public bool HavePermissionToAddTask() => this.User.Role == Role.Manager;
    }
}
