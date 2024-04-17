using Autofac;
using AutoMapper;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler
{
    public class UpdateBranchRequestHandler
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        private ICompanyManagementService _companyManagementService;
        private IMapper _mapper;
        public UpdateBranchRequestHandler()
        {

        }

        public UpdateBranchRequestHandler(ICompanyManagementService companyManagementService,IMapper mapper)
        {
            _companyManagementService = companyManagementService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task UpdateBranch()
        {
            await _companyManagementService.UpdateBranch(_mapper.Map<Branch>(this));
        }
    }
}
