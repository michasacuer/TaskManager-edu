namespace TaskManager_WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Task> GetTasks()
        {
            return this.taskService.GetList();
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public IActionResult GetTask([FromRoute] int id)
        {
            return this.Ok(this.taskService.GetItem(id));
        }

        [HttpGet("{userId}")]
        [Authorize]
        public IActionResult GetUserTask([FromRoute] string userId)
        {
            var task = this.taskService.GetUserTask(userId.ToString());

            if (task != null)
            {
                return this.Ok(task);
            }

            return this.NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Developer, Manager")]
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

        [HttpPut("{taskId}/{userId}")]
        [Authorize(Roles = "Developer, Manager")]
        public IActionResult TakeTaskByUser([FromRoute] int taskId, [FromRoute] string userId)
        {
            var task = this.taskService.TakeTaskByUser(taskId, userId);
            if (task == null)
            {
                return this.NotFound();
            }

            return this.Ok(task);
        }

        [HttpPut("End/{taskId}/{userId}")]
        [Authorize(Roles = "Developer, Manager")]
        public IActionResult EndTaskByUser([FromRoute] int taskId, [FromRoute] string userId)
        {
            this.taskService.EndTaskByUser(taskId, userId);
            return this.Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult PostTask([FromBody] Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.taskService.Add(task);

            return this.Ok(task);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
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
    }
}