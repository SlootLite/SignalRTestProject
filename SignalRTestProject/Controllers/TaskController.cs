using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLayer.Dto;
using CoreLayer.Interfaces.Services;
using CoreLayer.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SignalRTestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger,
            ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public IEnumerable<TaskItemView> Get()
        {
            return _taskService.Get();
        }
    }
}
