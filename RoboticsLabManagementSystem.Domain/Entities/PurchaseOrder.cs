using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class PurchaseOrder
    {
        public Guid PurchaseOrderId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public Threshold Threshold { get; set; }
    }

   
}
