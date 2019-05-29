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

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
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

          return this.Ok(project);
        }
    }
}