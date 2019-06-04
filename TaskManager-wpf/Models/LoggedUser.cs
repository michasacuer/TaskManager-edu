namespace TaskManager.WPF.Models
{
    using TaskManager.Models;
    using TaskManager.Models.Enums;

    public class LoggedUser
    {
        public static LoggedUser Instance { get; } = new LoggedUser();

        public WPFApplicationUser User { get; set; }

        private ActiveTask ActiveTask { get; set; } = new ActiveTask();

        public void LoginUserToApp(WPFApplicationUser user) => this.User = user;

        public void AttachTaskToUser(Task task) => this.ActiveTask.Task = task;

        public ActiveTask GetUserTask() => this.ActiveTask;

        public string GetFullName() => $"{this.User.FirstName} {this.User.LastName}";

        public string GetPosition() => this.User.Role.ToString();

        public void Logout()
        {
            this.User = null;
            this.ActiveTask = new ActiveTask();
        }

        public bool HavePermissionToTakeTask()
            => this.User.Role == Role.Manager || this.User.Role == Role.Developer;

        public bool IsManager() => this.User.Role == Role.Manager;
    }
}
