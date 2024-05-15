using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboticsLabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{


    public static class HolidaySeed
    {
        public static List<Holiday> GetSeedData()
        {
            List<Holiday> holidayList = new List<Holiday>();

            // Add sample holidays
            Holiday holiday1 = new Holiday
            {
                HolidayId = Guid.NewGuid(),
                Name = "New Year's Day",
                Date = new DateTime(DateTime.Now.Year, 1, 1)
            };
            holidayList.Add(holiday1);

            Holiday holiday2 = new Holiday
            {
                HolidayId = Guid.NewGuid(),
                Name = "Christmas",
                Date = new DateTime(DateTime.Now.Year, 12, 25)
            };
            holidayList.Add(holiday2);

            // Add more holidays as needed...

            return holidayList;
        }
    }

}
