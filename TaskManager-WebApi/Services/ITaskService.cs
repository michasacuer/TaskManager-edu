namespace TaskManager.WebApi.Services
{
    using TaskManager.Models;

    public interface ITaskService : IDatabaseService<Task>
    {
        Task TakeTaskByUser(int taskId, string userId);

        Task GetUserTask(string userId);
    }
}