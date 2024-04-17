using DevSkill.Data;
using DevSkill.Extensions.Paginate.Contracts;
using DevSkill.Extensions.Paginate.Extensions;
using DevSkill.Extensions.Queryable;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using RoboticsLabManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RoboticsLabManagementSystem.Infrastructure.Repositories
{
    public class BranchRepository: Repository<Branch, Guid>,IBranchRepository
    {
        public BranchRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }

        public async Task<IPaginate<Branch>> GetPaginateBranch(SearchRequest request, CancellationToken cancellationToken)
        {
            var total = await GetCountAsync();

            var data =Get(null, null, null);

            return await data.FilterBy(request.Filters)
            .OrderBy(request.SortOrders)
            .ToPaginateAsync(request.PageIndex, request.PageSize, total, 1, cancellationToken);
        }

        public bool IsDuplicateName(string name, Guid? id)
        {
            int? existingBranchCount = null;

            if (id.HasValue)
                existingBranchCount = GetCount(x => x.Name == name && x.Id != id.Value);
            else
                existingBranchCount = GetCount(x => x.Name == name);

            return existingBranchCount > 0;
        }
    }
}
