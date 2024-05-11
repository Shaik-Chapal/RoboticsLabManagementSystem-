using Autofac;
using RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboticsLabManagementSystem.Api.Controllers.Admin
{
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class UniversityController: ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILifetimeScope scope, ILogger<UniversityController> logger)
        {
            _scope = scope;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves information about the company.
        /// </summary>
        /// <returns>
        /// If the company information is successfully retrieved, returns a success response with the company data.
        /// If the company information is not found, returns a not found response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// This endpoint retrieves details about the company.
        /// 
        /// Sample response for a successful retrieval:
        /// 
        ///     {
        ///       "id": "f00918a5-3a59-4e3c-9a47-cf36930e7add",
        ///       "name": ""Oulu University of Applied Sciences",
        ///       "email": "info@OuluUniversity.com",
        ///       "phone": "+358 29 4480000",
        ///       "address": "Pentti Kaiteran katu 1, 90570 Oulu, Finland",
        ///       "logoUrl": "logo.url",
        ///       "website": "https://www.oulu.fi/en",
        ///       "branches": []
        ///     }
        /// </remarks>

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Company information retrieved successfully", typeof(GetCompanyRequestHandler))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Company information not found", typeof(void))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the process", typeof(IResult))]
        public async Task<IActionResult> GetCompany()
        {
            try
            {
                var requestHandler = _scope.Resolve<GetCompanyRequestHandler>();
                requestHandler.ResolveDependency(_scope);

                var data = await requestHandler.GetCompany();

                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }



        [HttpPost]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Company created successfully", typeof(CreateCompanyRequestHandler))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the process", typeof(IResult))]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyRequestHandler request)
        {
            try
            {
                request.ResolveDependency(_scope);
                await request.CreateCompany();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
           
        }




        /// <summary>
        /// Updates the company information.
        /// </summary>
        /// <param name="id">The ID of the company.</param>
        /// <param name="requestHandler">The request handler containing the updated company information.</param>
        /// <returns>No content.</returns>
        /// <response code="204">If the company information is updated successfully.</response>
        /// <response code="400">If there is an error updating the company information.</response>

        [HttpPut("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateCompanyRequestHandler requestHandler)
        {
            try
            {
                requestHandler.ResolveDependency(_scope);
                requestHandler.Id = id;

                await requestHandler.UpdateCompany();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest();
            }
        }
    }
}
