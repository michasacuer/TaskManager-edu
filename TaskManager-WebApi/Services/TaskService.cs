﻿namespace TaskManager.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class TaskService : IDatabaseService<Task>
    {
        private List<Task> Tasks { get; set; }

        private readonly TaskManagerDbContext context;

        public TaskService(TaskManagerDbContext context)
        {
            this.context = context;
            this.Tasks = this.context.Tasks.ToList();
        }

        public void Add(Task data)
        {
            throw new NotImplementedException();
        }

        public void Edit(Task data)
        {
            throw new NotImplementedException();
        }

        public Task GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(Task data)
        {
            throw new NotImplementedException();
        }
    }
}