using Autofac;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler
{
    public class GetCompanyRequestHandler
    {
        private ICompanyManagementService _companyManagementService;
        public GetCompanyRequestHandler(ICompanyManagementService companyManagementService)
        {
            _companyManagementService = companyManagementService;
        }

        public GetCompanyRequestHandler()
        {
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
        }

        internal async Task<Company> GetCompany()
        {
            var data = await _companyManagementService.GetCompany();
            return data;
        }
    }
}
