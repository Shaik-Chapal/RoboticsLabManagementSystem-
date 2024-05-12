using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Domain.Entities
{
    public class FeaturedContent
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ContentType { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Summary { get; set; }
        public string FullContentLink { get; set; }
        public string ThumbnailImage { get; set; }
    }
}
