namespace TaskManager.WebApi.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class ProjectService : IProjectService
    {
        private readonly TaskManagerDbContext context;

        public ProjectService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public Project Add(Project data)
        {
            this.context.Projects.Add(data);
            this.context.SaveChanges();
            return data;
        }

        public Project Edit(Project data)
        {
            this.context.Entry(data).State = EntityState.Modified;
            this.context.SaveChanges();
            return data;
        }

        public Project GetItem(int id)
        {
            var project = this.context.Projects.Find(id);

            if (project != null)
            {
                return project;
            }

            return null;
        }

        public IEnumerable<Project> GetList()
        {
            return this.context.Projects.Include(project => project.Tasks).ToList();

        }

        public void Remove(Project data)
        {
            this.context.Projects.Remove(data);
            this.context.SaveChanges();
        }
    }
}
