using Autofac;
using AutoMapper;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler
{
    public class AddBranchRequestHandler
    {
        public Guid CompanyId { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        private ICompanyManagementService _companyManagementService;
        private IMapper _mapper;
        public AddBranchRequestHandler()
        {

        }

        public AddBranchRequestHandler(ICompanyManagementService companyManagementService, IMapper mapper)
        {
            _companyManagementService = companyManagementService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task AddBranch()
        {
            var branch = _mapper.Map<Branch>(this);
            await _companyManagementService.AddBranch(branch);
        }
    }
}
