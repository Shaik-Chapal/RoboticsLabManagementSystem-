
namespace RoboticsLabManagementSystem.Application.ExternalServices
{
    public interface ICaptchaVerificationService
    {
        Task<bool> VerifyCaptchaToken(string token);
    }
}