using DevSkill.Data;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Domain.Repositories
{
    public interface ICompanyRepository : IRepository<Company, Guid>
    {
    }
}