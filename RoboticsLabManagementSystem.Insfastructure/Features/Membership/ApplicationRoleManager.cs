﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace RoboticsLabManagementSystem.Infrastructure.Features.Membership
{
    public class ApplicationRoleManager
		: RoleManager<ApplicationRole>
	{
		public ApplicationRoleManager(IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRole>> logger)
			: base(store, roleValidators, keyNormalizer, errors, logger)
		{
		}
	}
}
