using DevSkill.Data;
using RoboticsLabManagementSystem.Domain.Repositories;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using Microsoft.EntityFrameworkCore;

namespace RoboticsLabManagementSystem.Infrastructure.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser, Guid>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
