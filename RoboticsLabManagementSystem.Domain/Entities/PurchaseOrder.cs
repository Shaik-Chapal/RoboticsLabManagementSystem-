using RoboticsLabManagementSystem.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class PurchaseOrder
    {
        public Guid PurchaseOrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public Guid EquipmentId { get; set; }
        public string Company { get; set; }
        public string Origin { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public Equipment Equipment { get; set; }
    }
    public class PurchaseOrderDto
    {
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }
        public Guid EquipmentId { get; set; }
        public string Company { get; set; }
        public string Origin { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public DateTime CreateDate { get; set; }
    }


}
