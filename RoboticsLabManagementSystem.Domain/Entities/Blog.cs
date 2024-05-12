using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class Blog
    {
        public Guid BlogId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }
        public string ThumbnailImage { get; set; } 
    }
}
