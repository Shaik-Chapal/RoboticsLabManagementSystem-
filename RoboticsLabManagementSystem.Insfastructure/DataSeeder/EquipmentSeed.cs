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
                EquipmentName = "Microscope",
                Description = "High-powered microscope for lab use",
                Quantity = 5,
                Location = "Lab Room A",
                LastMaintenanceDate = DateTime.Parse("2024-04-20"),
                Manufacturer = "Company X",
                ModelNumber = "ABC123",
                Company = "Oulu University of Applied Sciences",
                Origin = "Finland"
            };
            equipmentList.Add(equipment1);

            Equipment equipment2 = new Equipment
            {
                EquipmentID = Guid.NewGuid(),
                EquipmentName = "Spectrophotometer",
                Description = "Analytical instrument for measuring absorbance",
                Quantity = 3,
                Location = "Lab Room B",
                LastMaintenanceDate = DateTime.Parse("2024-03-15"),
                Manufacturer = "Company Y",
                ModelNumber = "XYZ789",
                Company = "Oulu University of Applied Sciences",
                Origin = "Finland"
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
