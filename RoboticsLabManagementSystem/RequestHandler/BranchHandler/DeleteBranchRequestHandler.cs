using Autofac;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;

namespace RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler
{
    public class DeleteBranchRequestHandler
    {
        private ICompanyManagementService _companyManagementService;
        public DeleteBranchRequestHandler()
        {

        }
        public DeleteBranchRequestHandler(ICompanyManagementService companyManagementService)
        {
            _companyManagementService = companyManagementService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
        }

        internal async Task DeleteBranch(Guid id)
        {
            await _companyManagementService.DeleteBranch(id);
        }
    }
}
