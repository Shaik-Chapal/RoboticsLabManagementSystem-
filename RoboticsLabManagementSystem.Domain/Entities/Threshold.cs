namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class Threshold
    {
        public Guid ThresholdId { get; set; }
        public Guid ItemId { get; set; }
        public int LowStockThreshold { get; set; }
        public string NotificationMethod { get; set; }
    }

}
