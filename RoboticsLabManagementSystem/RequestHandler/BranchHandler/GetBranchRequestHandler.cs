using Autofac;
using DevSkill.Extensions.Paginate.Contracts;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler
{
    public class GetBranchRequestHandler
    {
        private ICompanyManagementService _companyManagementService;
        public GetBranchRequestHandler()
        {

        }

        public GetBranchRequestHandler(ICompanyManagementService companyManagementService)
        {
            _companyManagementService = companyManagementService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
        }

        internal async Task<Branch> GetBranch(Guid id)
        {
            return await _companyManagementService.GetBranch(id);
        }

        internal async Task<IPaginate<Branch>> GetBranchList(SearchRequest request, CancellationToken cancellationToken)
        {
            return await _companyManagementService.GetBranches(request, cancellationToken);
        }
    }
}
