using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.Dto
{
    public class BranchDto
    {
     
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
    }
}
