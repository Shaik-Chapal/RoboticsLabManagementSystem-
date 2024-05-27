using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.Dto
{
    public class UniversityUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Address { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public string? LogoUrl { get; set; }

        [Required]
        public string Website { get; set; }
    }

}
