namespace TaskManager.WebApi.Services
{
    using System.Collections.Generic;
    using TaskManager.Models;

    public interface ITaskService : IDatabaseService<Task>
    {
        Task TakeTaskByUser(int taskId, string userId);
    }
}