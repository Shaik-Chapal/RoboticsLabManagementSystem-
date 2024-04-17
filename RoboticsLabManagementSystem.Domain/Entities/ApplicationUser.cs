using DevSkill.Data;
using Microsoft.AspNetCore.Identity;

namespace RoboticsLabManagementSystem.Infrastructure.Features.Membership
{
    public class ApplicationUser :IdentityUser<Guid> , IEntity<Guid>
	{
        public override Guid Id { get; set; }

    }
}
