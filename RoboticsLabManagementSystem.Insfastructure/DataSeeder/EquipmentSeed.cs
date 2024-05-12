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

}
