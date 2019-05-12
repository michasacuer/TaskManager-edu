namespace TaskManager_WebApi.Controllers
{
    using System.Collections;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DatabaseService databaseService;

        public TestController(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok();
        }
    }
}
