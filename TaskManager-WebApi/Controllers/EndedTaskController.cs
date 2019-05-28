﻿namespace TaskManager_WebApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Models;
    using TaskManager.WebApi.Services;

    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class EndedTaskController : ControllerBase
    {
        private readonly IEndedTaskService endedTaskService;

        public EndedTaskController(IEndedTaskService endedTaskService)
        {
            this.endedTaskService = endedTaskService;
        }

        [HttpGet]
        public IEnumerable<EndedTask> GetEndedTasks()
        {
            return this.endedTaskService.GetList();
        }
    }
}