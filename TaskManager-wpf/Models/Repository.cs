﻿namespace TaskManager.WPF.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Caliburn.Micro;
    using TaskManager.WPF.Services;

    public class Repository
    {
        public static Repository Instance { get; } = new Repository();

        public IEnumerable<TaskManager.Models.Project> Projects { get; set; }

        public IEnumerable<TaskManager.Models.Task> Tasks { get; set; }

        public IEnumerable<TaskManager.Models.EndedTask> EndedTasks { get; set; }

        public IEnumerable<TaskManager.Models.Notification> Notifications { get; set; }

        public BindableCollection<string> NotificationsMessages { get; set; }

        public async Task FetchAll()
        {
            var httpDataService = new HttpDataService();

            this.Projects = await httpDataService.Get<TaskManager.Models.Project>();
            this.Tasks = await httpDataService.Get<TaskManager.Models.Task>();
            this.EndedTasks = await httpDataService.Get<TaskManager.Models.EndedTask>();
            this.Notifications = await httpDataService.Get<TaskManager.Models.Notification>();

            this.NotificationsMessages = new BindableCollection<string>();

            foreach (var notification in this.Notifications)
            {
                this.NotificationsMessages.Add(notification.Message);
            }
        }

        public async Task FetchUpdates()
        {
            var httpDataService = new HttpDataService();

            this.Projects = await httpDataService.Get<TaskManager.Models.Project>();
            this.Tasks = await httpDataService.Get<TaskManager.Models.Task>();
            this.EndedTasks = await httpDataService.Get<TaskManager.Models.EndedTask>();
        }
    }
}
