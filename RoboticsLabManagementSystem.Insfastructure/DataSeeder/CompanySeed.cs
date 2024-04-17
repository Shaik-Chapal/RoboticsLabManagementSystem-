using RoboticsLabManagementSystem.Domain.Entities.Company;

namespace RoboticsLabManagementSystem.Infrastructure.DataSeeder
{
    public static class CompanySeed
    {
        public static Company Claims()
        {
            var company = new Company()
            {
                Id = new Guid("f00918a5-3a59-4e3c-9a47-cf36930e7add"),
                Name = "Oulu University of Applied Sciences",
                Email = "info@OuluUniversity.com",
                Phone = "+358 29 4480000",
                Website = "https://www.oulu.fi/en",
                Address = "Pentti Kaiteran katu 1, 90570 Oulu, Finland"
            };
            return company;
        }
    }
}