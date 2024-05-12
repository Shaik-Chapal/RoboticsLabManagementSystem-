using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class Equipment
    {
        public Guid EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public string Company { get; set; }
        public string Origin { get; set; }
    }
}
