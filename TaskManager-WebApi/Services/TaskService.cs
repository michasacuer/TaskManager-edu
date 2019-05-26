namespace TaskManager.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class TaskService : ITaskService
    {
        private readonly TaskManagerDbContext context;

        public TaskService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public Task Add(Task data)
        {
            this.context.Tasks.Add(data);
            this.context.SaveChanges();

            return data;
        }

        public Task Edit(Task data)
        {
            this.context.Entry(data).State = EntityState.Modified;
            this.context.SaveChanges();

            return data;
        }

        public Task TakeTaskByUser(int taskId, string userId)
        {
            var task = this.GetItem(taskId);

            task.ApplicationUserId = userId;
            task.StartTime = DateTime.Now;

            this.context.Entry(task).State = EntityState.Modified;
            this.context.SaveChanges();

            return task;
        }

        public Task GetUserTask(string userId)
        {
            var userTask = this.context.Tasks.SingleOrDefault(t => t.ApplicationUserId == userId);

            if (userTask != null)
            {
                return userTask;
            }

            return null;
        }

        public Task GetItem(int id)
        {
            var task = this.context.Tasks.Find(id);

            if (task != null)
            {
                return task;
            }

            return null;
        }

        public IEnumerable<Task> GetList()
        {
            return this.context.Tasks.ToList();
        }

        public void Remove(Task data)
        {
            this.context.Tasks.Remove(data);
            this.context.SaveChanges();
        }
    }
}