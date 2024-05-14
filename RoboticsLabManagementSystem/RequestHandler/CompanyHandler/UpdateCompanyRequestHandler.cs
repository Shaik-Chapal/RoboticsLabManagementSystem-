using Autofac;
using AutoMapper;
using RoboticsLabManagementSystem.Application.Feature.Admin.Services;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler
{
    public class UpdateCompanyRequestHandler
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? LogoUrl { get; set; }
        public string Website { get; set; }
        public TimeSpan OpenTime { get; set; } = TimeSpan.Zero;
        public TimeSpan CloseTime { get; set; } = TimeSpan.Zero;


        private ICompanyManagementService _companyManagementService;
        private IMapper _mapper;
        public UpdateCompanyRequestHandler(ICompanyManagementService companyManagementService,IMapper mapper)
        {
            _companyManagementService = companyManagementService;
            _mapper = mapper;
        }

        public UpdateCompanyRequestHandler()
        {
        }

        internal void ResolveDependency(ILifetimeScope scope)
        {
            _companyManagementService = scope.Resolve<ICompanyManagementService>();
            _mapper = scope.Resolve<IMapper>();
        }

        internal async Task UpdateCompany()
        {
            await _companyManagementService.UpdateCompany(_mapper.Map<Company>(this));
        }
    }
}
