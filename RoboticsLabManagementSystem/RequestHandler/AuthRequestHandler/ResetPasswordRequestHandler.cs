namespace RoboticsLabManagementSystem.Api.RequestHandler.AuthRequestHandler
{
    public class ResetPasswordRequestHandler
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}