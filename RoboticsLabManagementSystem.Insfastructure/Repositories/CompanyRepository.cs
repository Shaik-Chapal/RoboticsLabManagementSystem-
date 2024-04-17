using DevSkill.Data;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using RoboticsLabManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RoboticsLabManagementSystem.Infrastructure.Repositories
{
    public class CompanyRepository :Repository<Company,Guid>, ICompanyRepository
    {
        public CompanyRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }
    }
}
