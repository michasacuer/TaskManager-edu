namespace TaskManager.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class ProjectService : IDatabaseService<Project>
    {
        private readonly TaskManagerDbContext context;

        public ProjectService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public Project Add(Project data)
        {
            throw new NotImplementedException();
        }

        public Project Edit(Project data)
        {
            throw new NotImplementedException();
        }

        public Project GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetList()
        {
            throw new NotImplementedException();
        }

        public Project Remove(Project data)
        {
            throw new NotImplementedException();
        }
    }
}
