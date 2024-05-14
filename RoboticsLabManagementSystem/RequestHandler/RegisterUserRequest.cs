using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.RequestHandler
{
    public class RegisterUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least {0} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }

        [Required]
        public UserRole UserRole { get; set; }
    }

    public enum UserRole
    {
        Staff,
        Student
    }
}
