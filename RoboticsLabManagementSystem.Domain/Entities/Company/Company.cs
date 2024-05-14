using DevSkill.Data;
using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.Domain.Entities.Company
{
    public class Company:IEntity<Guid>
    {
        public Guid Id { get; set; }
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
        public IList<Branch>? Branches { get; set; } = new List<Branch>();
    }
}