using Autofac;
using RoboticsLabManagementSystem.Application.ExternalServices;
using RoboticsLabManagementSystem.Domain.Utilities;

namespace RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler
{
    public class ForgotPasswordRequestHandler
    {

        public string Email { get; set; }

        private IEmailMessageService _emailMessageService;
        private IEmailService _emailService;

        public ForgotPasswordRequestHandler()
        {

        }
        public ForgotPasswordRequestHandler(IEmailService emailService, IEmailMessageService emailMessageService)
        {
            _emailMessageService = emailMessageService;
            _emailService = emailService;
        }
        public void ResolveDependency(ILifetimeScope scope)
        {
            _emailMessageService = scope.Resolve<IEmailMessageService>();
            _emailService = scope.Resolve<IEmailService>();
        }
        internal EmailSendingHelper CreateEmail(string email, string username, string callbackURL)
        {
            EmailSendingHelper emailhelper = _emailMessageService.CreatePasswordResetEmail(email, username, callbackURL);
            return emailhelper;
        }
        internal void SendPasswordResetEmail(string receiverName, string receiverEmail, string subject, string body)
        {
            _emailService.SendSingleEmail(receiverName, receiverEmail, subject, body);
        }
    }
}