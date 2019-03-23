using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;


namespace Rest.Models
{
    public class TaskManagerDbContext : IdentityDbContext<User>
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task>    Tasks    { get; set; }
        public DbSet<User>    Users    { get; set; }
    }
}
