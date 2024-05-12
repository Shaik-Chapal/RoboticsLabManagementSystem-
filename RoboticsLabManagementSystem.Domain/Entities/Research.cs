using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    using System;

    public class Research
    {
        public Guid ResearchId { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Summary { get; set; }
        public string FullTextLink { get; set; }
        public string ThumbnailImage { get; set; } // Optional
    }

   



}
