namespace TaskManager.WebApi.Models
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;

    public class TaskManagerDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
