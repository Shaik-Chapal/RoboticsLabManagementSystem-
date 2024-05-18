using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{
    using RoboticsLabManagementSystem.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public static class EquipmentSeed
    {
        public static List<Equipment> GetSeedData()
        {
            List<Equipment> equipmentList = new List<Equipment>();

           
            Equipment equipment1 = new Equipment
            {
                EquipmentID = Guid.NewGuid(),
                EquipmentName = "DC Power Supplies",
                Description = "High-powered DC Power Supplies for lab use",
                Quantity = 0,
                GroupID = new Guid("D4F37C25-6883-443D-A3E2-88966BE5D0F4"),
                Location = "Lab Room A",
  
            };
            equipmentList.Add(equipment1);

            Equipment equipment2 = new Equipment
            {
                EquipmentID = Guid.NewGuid(),
                EquipmentName = "Digital Multimeters (DMM)",
                Description = "Digital Multimeters (DMM)",
                Quantity = 0,
                GroupID = new Guid("659BBDA2-5C68-4FB6-8929-0ED791BF9A24"),
                Location = "Lab Room A",

            };
            equipmentList.Add(equipment2);

           

            return equipmentList;
        }
    }

    public static class SupplierSeed
    {
        public static List<Supplier> GetSeedData()
        {
            List<Supplier> supplierList = new List<Supplier>();

            Supplier supplier1 = new Supplier
            {
                SupplierId = Guid.NewGuid(),
                Name = "Supplier A",
                ContactPerson = "John Doe",
                Email = "john.doe@example.com",
                Phone = "+1234567890",
                Address = "123 Main Street, City, Country",
                CreatedAt = DateTime.UtcNow
            };
            supplierList.Add(supplier1);

            Supplier supplier2 = new Supplier
            {
                SupplierId = Guid.NewGuid(),
                Name = "Supplier B",
                ContactPerson = "Jane Smith",
                Email = "jane.smith@example.com",
                Phone = "+0987654321",
                Address = "456 Elm Street, City, Country",
                CreatedAt = DateTime.UtcNow
            };
            supplierList.Add(supplier2);

            // Add more suppliers as needed...

            return supplierList;
        }
    }

}
