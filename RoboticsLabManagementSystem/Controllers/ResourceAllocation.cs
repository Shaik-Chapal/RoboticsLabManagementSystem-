using Autofac;
using Microsoft.AspNetCore.Mvc;
using RoboticsLabManagementSystem.Api.Controllers.Admin;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ResourceAllocation : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public ResourceAllocation(ILifetimeScope scope, ILogger<DepartmentController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
