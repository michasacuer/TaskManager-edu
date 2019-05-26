namespace TaskManager.WebApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;

    public class EndedTaskService : IEndedTaskService
    {
        private readonly TaskManagerDbContext context;

        public EndedTaskService(TaskManagerDbContext context)
        {
            this.context = context;
        }

        public EndedTask Add(EndedTask data)
        {
            throw new NotImplementedException();
        }

        public EndedTask Edit(EndedTask data)
        {
            throw new NotImplementedException();
        }

        public EndedTask GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EndedTask> GetList()
        {
            return this.context.EndedTasks.ToList();
        }

        public void Remove(EndedTask data)
        {
            throw new NotImplementedException();
        }
    }
}
