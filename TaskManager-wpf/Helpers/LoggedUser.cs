namespace TaskManager.WPF.Helpers
{
    using TaskManager.Models;
    using TaskManager.Models.Enums;
    using TaskManager.WPF.Models;

    public class LoggedUser
    {
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
            this.ActiveTask = null;
        }

        public bool HavePermissionToTakeTask()
            => this.User.Role == Role.Manager || this.User.Role == Role.Developer;

        public bool HavePermissionToAddTask() => this.User.Role == Role.Manager;
    }
}
