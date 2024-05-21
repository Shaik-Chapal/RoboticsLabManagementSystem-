namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class Equipment
    {
        public Guid EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string GroupID { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }

    }
    public class EquipmentDto
    {
        public Guid EquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string GroupID { get; set; }
    }

}
