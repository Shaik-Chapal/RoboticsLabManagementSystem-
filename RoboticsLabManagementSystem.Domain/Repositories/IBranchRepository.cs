using DevSkill.Data;
using DevSkill.Extensions.Paginate.Contracts;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Domain.Repositories
{
    public interface IBranchRepository:IRepository<Branch, Guid>
    {
        Task<IPaginate<Branch>> GetPaginateBranch(SearchRequest request, CancellationToken cancellationToken);
        bool IsDuplicateName(string name, Guid? id);
    }
}