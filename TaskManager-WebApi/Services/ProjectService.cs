namespace TaskManager.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class ProjectService : IDatabaseService<Project>
    {
        public ProjectService(TaskManagerDbContext context)
        {
            this.Projects = context.Projects;
        }

        private DbSet<Project> Projects { get; set; }

        public void Add(Project data)
        {
            throw new NotImplementedException();
        }

        public void Edit(Project data)
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

        public void Remove(Project data)
        {
            throw new NotImplementedException();
        }
    }
}
