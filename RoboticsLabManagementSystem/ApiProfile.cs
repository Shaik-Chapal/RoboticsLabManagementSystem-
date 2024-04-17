using AutoMapper;
using RoboticsLabManagementSystem.Api.RequestHandler.BranchHandler;
using RoboticsLabManagementSystem.Api.RequestHandler.CompanyHandler;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Api
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<UpdateCompanyRequestHandler,Company>()
                .ReverseMap();

            CreateMap<AddBranchRequestHandler, Branch>()
                .ReverseMap();

            CreateMap<UpdateBranchRequestHandler, Branch>()
                .ReverseMap();

            CreateMap<CreateCompanyRequestHandler, Company>();
        }
    }
}
