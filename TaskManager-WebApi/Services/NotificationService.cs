namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.SignalR;
    using TaskManager.Models;
    using TaskManager.WebApi.Hubs;
    using TaskManager.WebApi.Models;

    public class NotificationService : INotificationService
    {
        private readonly TaskManagerDbContext context;

        private readonly IAccountService accountService;

        private readonly IHubContext<NotificationsHub> notificationsHub;

        public NotificationService(TaskManagerDbContext context, IHubContext<NotificationsHub> notificationsHub, IAccountService accountService)
        {
            this.context = context;
            this.notificationsHub = notificationsHub;
            this.accountService = accountService;
        }

        public IEnumerable<Notification> GetList()
        {
            return this.context.Notifications.ToList();
        }

        public async void SendNotification(string message)
        {
            await this.notificationsHub.Clients.All.SendAsync("ReciveServerUpdate", message);

            this.context.Notifications.Add(new Notification
            {
                Message = message
            });

            this.context.SaveChanges();
        }

        public async void SendNotification(string userId, string message)
        {
            var userFullname = this.accountService.GetUserFullname(userId);

            await this.notificationsHub.Clients.All.SendAsync("ReciveServerUpdate", userFullname + " " + message);

            this.context.Notifications.Add(new Notification
            {
                Message = message
            });

            this.context.SaveChanges();
        }
    }
}