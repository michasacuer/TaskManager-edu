namespace TaskManager_WebApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        private readonly INotificationService notificationService;

        public ProjectController(IProjectService projectService, INotificationService notificationService)
        {
            this.projectService = projectService;
            this.notificationService = notificationService;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Project> GetProjects()
        {
            return this.projectService.GetList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetProject([FromRoute] int id)
        {
            return this.Ok(this.projectService.GetItem(id));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != project.Id)
            {
                return this.BadRequest();
            }

            this.projectService.Edit(project);
            this.notificationService.SendNotification($"Zedytowanie projekt - {project.Name}");


            return this.Ok(project);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult PostProject([FromBody] Project project)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.projectService.Add(project);
            this.notificationService.SendNotification($"Dodano projekt - {project.Name}");

            return this.Ok(project);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteProject([FromRoute] int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var project = this.projectService.GetItem(id);
            if (project == null)
            {
                return this.NotFound();
            }

            this.projectService.Remove(project);
            this.notificationService.SendNotification($"Usunięt projekt - {project.Name}");

            return this.Ok(project);
        }
    }
}