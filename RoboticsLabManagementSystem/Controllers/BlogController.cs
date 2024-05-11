using Autofac;
using Microsoft.AspNetCore.Mvc;
using RoboticsLabManagementSystem.Api.Controllers.Admin;
using RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public BlogController(ILifetimeScope scope, ILogger<DepartmentController> logger)
        {
            _scope = scope;
            _logger = logger;
        }


        [SwaggerResponse(StatusCodes.Status200OK, "Branch information retrieved successfully", typeof(GetBranchRequestHandler))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Branch information not found", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the process", typeof(IResult))]
        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            return Ok();
        }

    }
}
