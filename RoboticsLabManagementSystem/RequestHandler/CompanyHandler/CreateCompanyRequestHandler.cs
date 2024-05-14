using Autofac;
using AutoMapper;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler
{
    public class CreateCompanyRequestHandler
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string OpenTime { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public string Website { get; set; } = string.Empty;

        private ICompanyManagementService _companyManagementService;
        private IMapper _mapper;

        public CreateCompanyRequestHandler()
        {
        }

        public CreateCompanyRequestHandler(ICompanyManagementService companyManagementService, IMapper mapper)
        {
            _companyManagementService = companyManagementService;
            _mapper = mapper;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task CreateCompany()
        {
            var company = _mapper.Map<Company>(this);
            await _companyManagementService.CreateCompany(company);
        }
    }


}
