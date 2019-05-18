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
        private readonly TaskManagerDbContext context;

        private readonly IDatabaseService<Project> projectService;

        public ProjectController(TaskManagerDbContext context, IDatabaseService<Project> projectService)
        {
            this.context = context;
            this.projectService = projectService;
        }

        // GET: api/Project
        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return context.Projects.Include(t => t.Tasks);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.Id)
            {
                return BadRequest();
            }

            context.Entry(project).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //comment 

        // POST: api/Project
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            context.Projects.Remove(project);
            await context.SaveChangesAsync();

            return Ok(project);
        }

        private bool ProjectExists(int id)
        {
            return context.Projects.Any(e => e.Id == id);
        }
    }
}