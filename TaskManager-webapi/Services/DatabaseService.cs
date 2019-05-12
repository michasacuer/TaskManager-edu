namespace TaskManager.WebApi.Services
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskManager.WebApi.Models;

    public class DatabaseService
    {
        public DatabaseService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        private readonly TaskManagerDbContext context;

        public DbSet<TEntity> GetAll<TEntity>()
            where TEntity : class
        {
            return this.context.Set<TEntity>();
        }
    }
}
