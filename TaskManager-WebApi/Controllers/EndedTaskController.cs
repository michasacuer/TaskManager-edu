namespace TaskManager_WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    public class EndedTaskController : ControllerBase
    {
        private readonly IEndedTaskService endedTaskService;

        public EndedTaskController(IEndedTaskService endedTaskService)
        {
            this.endedTaskService = endedTaskService;
        }

        [HttpGet]
        public IEnumerable<Task> GetEndedTasks()
        {
            return this.endedTaskService.GetList();
        }
    }
}