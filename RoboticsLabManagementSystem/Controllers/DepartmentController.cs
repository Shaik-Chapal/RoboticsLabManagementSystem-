using Autofac;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace RoboticsLabManagementSystem.Api.Controllers.Admin
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILifetimeScope scope, ILogger<DepartmentController> logger)
        {
            _scope = scope;
            _logger = logger;
        }



        /// <summary>
        /// Retrieves information about a specific branch based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the branch.</param>
        /// <returns>
        /// If the branch information is successfully retrieved, returns a success response with the branch data.
        /// If the branch information is not found, returns a not found response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// This endpoint retrieves details about a specific branch.
        /// 
        /// Sample response for a successful retrieval:
        /// 
        ///     {
        ///       "id": "21050383-8660-4909-7b6e-08dc12aad12b",
        ///       "name": "Information Technology Lab",
        ///       "address": "Information Technology B",
        ///       "phone": "",
        ///       "companyId": "f00918a5-3a59-4e3c-9a47-cf36930e7add",
        ///       "company": "Oulu University of Applied Sciences"
        ///     }
        /// </remarks>
        
        [HttpGet()]
        [SwaggerResponse(StatusCodes.Status200OK, "Branch information retrieved successfully", typeof(GetBranchRequestHandler))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Branch information not found", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the process", typeof(IResult))]
        public async Task<IActionResult> GetBranch()
        {
            try
            {
                var requestHandler = _scope.Resolve<GetBranchRequestHandler>();
                requestHandler.ResolveDependency(_scope);

                var data = await requestHandler.GetBranch();

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

        /// <summary>
        /// Retrieves a list of branches based on the provided search criteria.
        /// </summary>
        /// <param name="request">The search criteria for retrieving branches.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// If branches are successfully retrieved, returns a success response with the list of branches.
        /// If no branches are found, returns a not found response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///       "pageIndex": 1,
        ///       "pageSize": 10,
        ///       "filters": [
        ///         {
        ///           "filterBy": "name",
        ///           "operator": 1,
        ///           "value": "New Branch",
        ///           "isGenericValue": false
        ///         }
        ///       ],
        ///       "sortOrders": [
        ///         {
        ///           "sortBy": "name",
        ///           "order": 2
        ///         }
        ///       ]
        ///     }
        /// 
        /// Sample response for a successful retrieval:
        /// 
        ///     {
        ///       "index": 1,
        ///       "size": 10,
        ///       "totalFiltered": 1,
        ///       "total": 1,
        ///       "pages": 1,
        ///       "from": 1,
        ///       "items": [
        ///         {
        ///           "id": "21050383-8660-4909-7b6e-08dc12aad12b",
        ///           "name": "New Branch",
        ///           "address": "Mirpur 10",
        ///           "phone": "01799999999",
        ///           "companyId": "f00918a5-3a59-4e3c-9a47-cf36930e7add",
        ///           "company": null
        ///         }
        ///       ],
        ///       "hasPrevious": false,
        ///       "hasNext": false
        ///     }
        /// </remarks>
      //  [Authorize(Policy = "AdminManager")]
        [HttpPost("list")]
        [SwaggerResponse(StatusCodes.Status200OK, "Branches retrieved successfully", typeof(GetBranchRequestHandler))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No branches found", typeof(IResult))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the process", typeof(IResult))]
        public async Task<IActionResult> GetBranches(SearchRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requestHandler = _scope.Resolve<GetBranchRequestHandler>();

                var data = await requestHandler.GetBranchList(request, cancellationToken);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't get branches");
                return BadRequest("{tan}");
            }
        }

        /// <summary>
        /// Adds a new branch with the provided information.
        /// </summary>
        /// <param name="request">The request containing information for adding a new branch.</param>
        /// <returns>
        /// If the branch is successfully added, returns a no content response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// This endpoint adds a new branch with the specified details.
        /// 
        /// Sample request:
        /// 
        ///     {
        ///       "name": "HQ",
        ///       "address": "Demo Address",
        ///       "phone": "0155555555"
        ///     }
        /// </remarks>
  
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Branch added successfully", typeof(void))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the add process", typeof(IResult))]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchRequestHandler request)
        {
            try
            {
                request.ResolveDependency(_scope);
                await request.AddBranch();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates information about a specific branch based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the branch.</param>
        /// <param name="request">The request containing updated branch information.</param>
        /// <returns>
        /// If the branch is successfully updated, returns a no content response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// This endpoint updates details about a specific branch.
        /// 
        /// Sample request:
        /// 
        ///     {
        ///       "name": "New Branch",
        ///       "address": "",
        ///       "phone": "8888"
        ///     }
        /// </remarks>
       // [Authorize(Policy = "AdminManager")]
        [HttpPut("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Branch information updated successfully", typeof(void))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the update process", typeof(IResult))]
        public async Task<IActionResult> UpdateBranch([FromRoute] Guid id, [FromBody] UpdateBranchRequestHandler request)
        {
            try
            {
                request.ResolveDependency(_scope);
                request.Id = id;

                await request.UpdateBranch();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes a specific branch based on its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the branch to be deleted.</param>
        /// <returns>
        /// If the branch is successfully deleted, returns a no content response.
        /// If an error occurs during the process, returns a bad request response.
        /// </returns>
        /// <remarks>
        /// This endpoint deletes a specific branch.
        /// </remarks>
       // [Authorize(Policy = "AdminManager")]
        [HttpDelete("{id:guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Branch deleted successfully", typeof(void))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Error during the delete process", typeof(IResult))]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var request = _scope.Resolve<DeleteBranchRequestHandler>();
                await request.DeleteBranch(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

    }
}
