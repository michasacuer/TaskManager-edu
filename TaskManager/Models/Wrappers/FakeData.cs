using System.Collections.Generic;
using TaskManager.Enums;
using System.Linq;

namespace TaskManager.Models
{
    public class FakeData
    {
        public FakeData()
        {
            users = new List<User>
            {
                new User("admin", "admin", "Michał", "Szewczak", "michasacuer3@gmail.com", Position.Manager),
                new User("login", "login", "Adam", "Kowalski", "temp@op.pl", Position.Developer),
                new User("test", "test", "Maciej", "Nowak", "temp2@op.pl", Position.Viewer)
            };

            projects = new List<Project>
            {
                new Project("Farm"),
                new Project("Mini Jira", new List<Task>
                {
                    new Task("Add first functionality", Priority.Low, "First task for our project"),
                    new Task("Add second functionality", Priority.High, "Very important"),
                    new Task("Add third functionality", Priority.Medium, "")
                })
            };
        }

        public List<User> GetUsers() => users;
        public User GetUser(string login) => users.FirstOrDefault(u => u.Login == login);

        private List<User> users { get; set; }
        private List<Project> projects { get; set; }

    }
}
