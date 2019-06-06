namespace TaskManager_WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok();
        }
    }
}
