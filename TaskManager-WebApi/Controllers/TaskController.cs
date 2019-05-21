namespace TaskManager_WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService taskService;
        private readonly IAccountService accountService;

        public TaskController(IDatabaseService<Task> taskService, IAccountService accountService)
        {
            this.taskService = (TaskService)taskService;
            this.accountService = accountService;
        }

        // GET: api/Task
        [HttpGet]
        public IEnumerable<Task> GetTasks()
        {
            return this.taskService.GetList();
        }

        // GET: api/Task/5
        [HttpGet("{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
            return this.Ok(this.taskService.GetItem(id));
        }

        // PUT: api/Task/5
        [HttpPut("{id}")]
        public IActionResult PutTask([FromRoute] int id, [FromBody] Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != task.Id)
            {
                return this.BadRequest();
            }

            this.taskService.Edit(task);

            return this.Ok(task);
        }

        // PUT: api/Task/userid
        [HttpPut("{id}")]
        public IActionResult TakeTaskByUser([FromRoute] Task task, [FromRoute] string userId)
        {
            this.taskService.TakeTaskByUser(task, userId);

            return this.Ok(task);
        }

        // POST: api/Task
        [HttpPost]
        public IActionResult PostTask([FromBody] Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.taskService.Add(task);

            return this.Ok(task);
        }

        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var task = this.taskService.GetItem(id);
            if (task == null)
            {
                return this.NotFound();
            }

            this.taskService.Remove(task);

            return this.Ok(task);
        }

        private bool TaskExists(int id)
        {
            return this.taskService.GetList().Any(e => e.Id == id);
        }
    }
}