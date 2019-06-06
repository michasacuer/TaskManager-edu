namespace TaskManager_WebApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        private readonly INotificationService notificationService;

        public TaskController(ITaskService taskService, INotificationService notificationService)
        {
            this.taskService = taskService;
            this.notificationService = notificationService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<TaskManager.Models.Task> GetTasks()
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
        public IActionResult PutTask([FromRoute] int id, [FromBody] TaskManager.Models.Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var taskToEdit = this.taskService.GetItem(id);
            if (id != task.Id || taskToEdit == null)
            {
                return this.NotFound();
            }

            this.taskService.Edit(task);
            this.notificationService.SendNotification($"Zedytowano task - {task.Name}");

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

            this.notificationService.SendNotification(userId, $" zaczął pracę nad taskiem ID: {task.Id}");

            return this.Ok(task);
        }

        [HttpPut("End/{taskId}/{userId}")]
        [Authorize(Roles = "Developer, Manager")]
        public IActionResult EndTaskByUser([FromRoute] int taskId, [FromRoute] string userId)
        {
            this.taskService.EndTaskByUser(taskId, userId);
            this.notificationService.SendNotification(userId, $" zakończył zadanie ID: {taskId}");

            return this.Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult PostTask([FromBody] TaskManager.Models.Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.taskService.Add(task);
            this.notificationService.SendNotification($"Dodano task - {task.Name}");

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
            this.notificationService.SendNotification($"Usunięto task - {task.Name}");

            return this.Ok(task);
        }
    }
}