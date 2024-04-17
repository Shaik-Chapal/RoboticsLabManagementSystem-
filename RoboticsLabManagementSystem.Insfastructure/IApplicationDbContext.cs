using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using Microsoft.EntityFrameworkCore;

namespace RoboticsLabManagementSystem.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}