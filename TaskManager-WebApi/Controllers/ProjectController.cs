namespace TaskManager_WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Models;
    using TaskManager.WebApi.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService projectService;

        public ProjectController (IProjectService projectService)
        {
            this.projectService = projectService;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return this.projectService.GetList();
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public IActionResult GetProject([FromRoute] int id)
        {
            return this.Ok(this.projectService.GetItem(id));
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
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
       

        // POST: api/Project
        [HttpPost]
        public IActionResult PostProject([FromBody] Project project)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            return this.Ok(project);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
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