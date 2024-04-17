using RoboticsLabManagementSystem.Domain.Utilities;

namespace RoboticsLabManagementSystem.Application.ExternalServices
{
    public interface IEmailMessageService
    {
        EmailSendingHelper CreatePasswordResetEmail(string receiverEmail, string receiverName, string confirmationLink);
    }
}