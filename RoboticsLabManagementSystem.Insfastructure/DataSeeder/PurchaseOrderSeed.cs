using RoboticsLabManagementSystem.Domain.Entities;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{
    public static class PurchaseOrderSeed
    {
        public static PurchaseOrder[] GetSeedData()
        {
            return new PurchaseOrder[]
            {
            new PurchaseOrder
            {
                PurchaseOrderId = Guid.NewGuid(),
                ItemName = "Item 1",
                Quantity = 10,
              
                Price = 10,
            },
            new PurchaseOrder
            {
                PurchaseOrderId = Guid.NewGuid(),
                ItemName = "Item 2",
                Quantity = 15,
              
                Price = 15
            }
            
            };
        }
    }

    public static class ThresholdSeed
    {
        public static Threshold[] GetSeedData()
        {
            return new Threshold[]
            {
            new Threshold
            {
                ThresholdId = Guid.NewGuid(),
                ItemId = Guid.NewGuid(), 
                LowStockThreshold = 5,
                NotificationMethod = "Email"
            }
           
            };
        }
    }

   

}
