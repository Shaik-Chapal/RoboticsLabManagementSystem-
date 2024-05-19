using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class EquipmentLog
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int EquipmentId { get; set; }

        [Required]
        public string Action { get; set; } // "Book", "Use", "Return", "Damage"

        [Required]
        public DateTime ActionDate { get; set; }

        public DateTime? EndDate { get; set; } // For booking duration
    }
   
}
