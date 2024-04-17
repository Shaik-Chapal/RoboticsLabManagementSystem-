
namespace RoboticsLabManagementSystem.Application.ExternalServices
{
    public interface IEmailService
    {
        void SendSingleEmail(string receiverName, string receiverEmail, string subject, string body);
    }
}