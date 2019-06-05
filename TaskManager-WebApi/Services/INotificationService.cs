namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;
    using TaskManager.Models;

    public interface INotificationService
    {
        IEnumerable<Notification> GetList();

        void DeleteAllNotifications();

        void SendNotification(string message);

        void SendNotification(string userId, string message);
    }
}
