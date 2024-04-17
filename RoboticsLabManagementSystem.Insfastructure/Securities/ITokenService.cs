using System.Security.Claims;

namespace RoboticsLabManagementSystem.Infrastructure.Securities
{
    public interface ITokenService
    {
        Task<string> GetJwtToken(IList<Claim> claims);
    }
}