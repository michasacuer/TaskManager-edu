namespace TaskManager.WPF.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Caliburn.Micro;
    using TaskManager.WPF.Enums;

    public class FakeData
    {
        public FakeData() => this.InitData();

        public List<User> GetUsers() => this.users;

        public User GetUser(string login) => this.users.FirstOrDefault(u => u.UserName == login);

        public void AddUser(User user) => this.users.Add(user);

        public BindableCollection<string> GetProjectsName()
        {
            var projectsNames = new BindableCollection<string>();
            foreach (Project item in this.projects)
            {
                projectsNames.Add(item.Name);
            }

            return projectsNames;
        }

        public Task GetTask(string taskName, string projectName) =>
            this.projects.FirstOrDefault(p => p.Name == projectName)
            .Tasks.FirstOrDefault(t => t.Name == taskName.Substring(0, taskName.IndexOf(" -")));

        public List<Task> GetProjectsTasks(string projectName)
            => this.projects.FirstOrDefault(p => p.Name == projectName).Tasks;

        public void AddTaskToProject(Task task, string projectName)
            => this.projects.FirstOrDefault(p => p.Name == projectName).Tasks.Add(task);

        public void EndTask(Task task, string projectName)
        {
            this.projects.FirstOrDefault(p => p.Name == projectName).EndedTasks.Add(task);
            this.projects.FirstOrDefault(p => p.Name == projectName).Tasks.Remove(task);
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
                //new User("admin", "admin", "Michał", "Szewczak", "michasacuer3@gmail.com", Role.Manager),
                //new User("login", "login", "Adam", "Kowalski", "temp@op.pl", Role.Developer),
                //new User("test", "test", "Maciej", "Nowak", "temp2@op.pl", Role.Viewer)
            };

            this.projects = new List<Project>
            {
                new Project("Farm"),
                new Project("Mini Jira", new List<Task>
                {
                    new Task
                    {
                        Name = "Pierwszy task",
                        Priority = Priority.Low,
                        Description = "desc"
                    }
                })
            };
        }

        private List<User> users { get; set; }

        private List<Project> projects { get; set; }
    }
}
