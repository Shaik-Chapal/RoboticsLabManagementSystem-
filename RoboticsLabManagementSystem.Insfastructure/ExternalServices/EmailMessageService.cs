using RoboticsLabManagementSystem.Application.ExternalServices;
using RoboticsLabManagementSystem.Domain.Utilities;
using RoboticsLabManagementSystem.Infrastructure.EmailTemplates;
using System.Text.Encodings.Web;

namespace RoboticsLabManagementSystem.Infrastructure.ExternalServices
{
    public class EmailMessageService : IEmailMessageService
    {
        public EmailSendingHelper CreatePasswordResetEmail(string receiverEmail, string receiverName, string confirmationLink)
        {
            var template = new PasswordResetEmailTemplate(receiverName, HtmlEncoder.Default.Encode(confirmationLink));
            string body = template.TransformText();
            string subject = "Password Reset Request";

            EmailSendingHelper emailEssentials = new EmailSendingHelper()
            {
                Subject = subject,
                Body = body
            };

            return emailEssentials;
        }
    }
}
