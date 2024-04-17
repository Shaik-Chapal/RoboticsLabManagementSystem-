using DevSkill.Extensions.Paginate.Contracts;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Application.Feature.Admin.Services
{
    public interface ICompanyManagementService
    {
        Task UpdateCompany(Company entity);
        Task<Company> GetCompany();
        Task AddBranch(Branch entity);
        Task CreateCompany(Company entity);
        Task UpdateBranch(Branch entity);
        Task DeleteBranch(Guid id);
        Task<Branch> GetBranch(Guid id);
        Task<IPaginate<Branch>> GetBranches(SearchRequest request, CancellationToken cancellationToken);
    }
}
