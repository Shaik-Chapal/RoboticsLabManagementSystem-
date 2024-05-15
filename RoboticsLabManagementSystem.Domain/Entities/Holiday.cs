using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class Holiday
    {
        public Guid HolidayId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
