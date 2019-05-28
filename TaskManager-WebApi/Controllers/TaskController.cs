namespace TaskManager_WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using TaskManager.WebApi.Hubs;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;

        private readonly IHubContext<NotificationsHub> notificationsHub;

        public TaskController(ITaskService taskService, IHubContext<NotificationsHub> notificationsHub)
        {
            this.taskService = taskService;
            this.notificationsHub = notificationsHub;
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

            if (id != task.Id)
            {
                return this.BadRequest();
            }

            this.taskService.Edit(task);

            return this.Ok(task);
        }

        [HttpPut("{taskId}/{userId}")]
        [Authorize(Roles = "Developer, Manager")]
        public async Task<IActionResult> TakeTaskByUser([FromRoute] int taskId, [FromRoute] string userId)
        {
            var task = this.taskService.TakeTaskByUser(taskId, userId);
            if (task == null)
            {
                return this.NotFound();
            }

            await this.notificationsHub.Clients.All.SendAsync("TaskTakenByUser", "User take task!");

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
        //[Authorize(Roles = "Manager")]
        public async Task<IActionResult> PostTask([FromBody] TaskManager.Models.Task task)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.taskService.Add(task);

            await this.notificationsHub.Clients.All.SendAsync("ReciveServerUpdate", "New Task in database!");

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