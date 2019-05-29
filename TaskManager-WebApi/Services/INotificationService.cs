namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;
    using TaskManager.Models;

    public interface INotificationService
    {
        IEnumerable<Notification> GetList();

        void SendNotification(string message);
    }
}
