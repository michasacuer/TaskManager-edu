namespace TaskManager.WebApi.Services
{
    using TaskManager.WebApi.Models;

    public class NotificationService : INotificationService
    {
        private readonly TaskManagerDbContext context;

        public NotificationService(TaskManagerDbContext context)
        {
            this.context = context;
        }
    }
}
