using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class EquipmentLog
    {
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Action { get; set; } // "Book", "Use", "Return", "Damage"

        [Required]
        public DateTime ActionDate { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }

        public List<EquipmentLogItem> Items { get; set; }
    }

    public class EquipmentLogItem
    {
        public  Guid Id { get; set; } 

        [Required]
        public Guid EquipmentId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Guid EquipmentLogId { get; set; }
        [JsonIgnore]
        public EquipmentLog EquipmentLog { get; set; }
    }

    public class EquipmentLogRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Action { get; set; } // "Book", "Use", "Return", "Damage"

        public int Approval { get; set; } // 1 for approved, 0 for not approved

        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }

        [Required]
        public List<EquipmentLogRequestItem> Items { get; set; }
    }

    public class EquipmentLogRequestItem
    {
        [Required]
        public Guid EquipmentId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

   
}
