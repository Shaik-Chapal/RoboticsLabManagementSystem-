using RoboticsLabManagementSystem.Domain.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{

    public static class BranchSeed
    {
        public static List<Branch> GetSeedData()
        {
            List<Branch> branchList = new List<Branch>();

            // Sample data for branches
            Branch branch1 = new Branch
            {
                Id = Guid.NewGuid(),
                Name = "CSE",
                Address = "Address of CSE branch",
                Phone = "1234567890",
                CompanyId = new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"), 
                Company = null 
            };
            branchList.Add(branch1);

            Branch branch2 = new Branch
            {
                Id = Guid.NewGuid(),
                Name = "EEE",
                Address = "Address of EEE branch",
                Phone = "9876543210",
                CompanyId = new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"), // Replace with actual company ID
                Company = null // Set to null if not needed
            };
            branchList.Add(branch2);

            // Add more branches as needed...

            return branchList;
        }
    }
}
