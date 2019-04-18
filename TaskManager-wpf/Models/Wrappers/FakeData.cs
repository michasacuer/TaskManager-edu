namespace TaskManager.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.Enums;

    public class FakeData
    {
        public FakeData() => this.InitData();

        public List<User> GetUsers() => this.users;

        public User GetUser(string login) => this.users.FirstOrDefault(u => u.Login == login);

        public void AddUser(User user) => this.users.Add(user);

        public BindableCollection<string> GetProjectsName()
        {
            var projectsNames = new BindableCollection<string>();
            foreach (Project item in this.projects)
            {
                projectsNames.Add(item.ProjectName);
            }

            return projectsNames;
        }

        public Task GetTask(string taskName, string projectName) =>
            this.projects.FirstOrDefault(p => p.ProjectName == projectName)
            .Tasks.FirstOrDefault(t => t.TaskName == taskName.Substring(0, taskName.IndexOf(" -")));

        public List<Task> GetProjectsTasks(string projectName)
            => this.projects.FirstOrDefault(p => p.ProjectName == projectName).Tasks;

        public void AddTaskToProject(Task task, string projectName)
            => this.projects.FirstOrDefault(p => p.ProjectName == projectName).Tasks.Add(task);

        public void EndTask(Task task, string projectName)
        {
            this.projects.FirstOrDefault(p => p.ProjectName == projectName).EndedTasks.Add(task);
            this.projects.FirstOrDefault(p => p.ProjectName == projectName).Tasks.Remove(task);
        }

        public BindableCollection<string> GetEndedTasks()
        {
            var endedTasks = new BindableCollection<string>();
            foreach (Project project in this.projects)
            {
                endedTasks.Add(project.EndedTasks.ToString());
            }

            return endedTasks;
        }

        private void InitData()
        {
            this.users = new List<User>
            {
                new User("admin", "admin", "Michał", "Szewczak", "michasacuer3@gmail.com", Position.Manager),
                new User("login", "login", "Adam", "Kowalski", "temp@op.pl", Position.Developer),
                new User("test", "test", "Maciej", "Nowak", "temp2@op.pl", Position.Viewer)
            };

            this.projects = new List<Project>
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

        private List<User> users { get; set; }

        private List<Project> projects { get; set; }
    }
}
