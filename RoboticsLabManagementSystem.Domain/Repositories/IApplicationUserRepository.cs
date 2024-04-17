using DevSkill.Data;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;

namespace RoboticsLabManagementSystem.Domain.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser, Guid>
    {
    }
}
