using RoboticsLabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{
    public static class GroupModelSeed
    {
        public static List<Group> GetSeedData()
        {
            List<Group> groupList = new List<Group>();

            // Add sample groups
            Group group1 = new Group
            {
                Id = Guid.NewGuid(),
                Name = "Power Supplies"
            };
            groupList.Add(group1);

            Group group2 = new Group
            {
                Id = Guid.NewGuid(),
                Name = "Multimeters"
            };
            groupList.Add(group2);

            // Add more groups as needed...

            return groupList;
        }
    }
}
