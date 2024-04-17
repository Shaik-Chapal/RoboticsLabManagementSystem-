using DevSkill.Data;
using System.ComponentModel.DataAnnotations;

namespace RoboticsLabManagementSystem.Domain.Entities.Company
{
    public class Branch:IEntity<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}