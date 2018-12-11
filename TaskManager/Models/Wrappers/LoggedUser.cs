﻿using TaskManager.Enums;

namespace TaskManager.Models
{
    public class LoggedUser
    {
        public void LoginUserToApp(User user) => this.user = user;
        public User GetInstance() => user;
        public string GetFullName() => $"{user.FirstName} {user.LastName}";
        public string GetPosition() => user.Position.ToString();
        public void Logout() => user = null;
        public bool HavePermissionToTakeTask() =>
            user.Position == Position.Manager ? true :
            user.Position == Position.Developer ? true : false;
        public bool HavePermissionToAddTask() => user.Position == Position.Manager ? true : false;

        private User user { get; set; }
    }
}
