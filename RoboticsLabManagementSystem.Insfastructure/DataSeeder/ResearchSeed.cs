using RoboticsLabManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Insfastructure.DataSeeder
{
    public static class ResearchSeed
    {
        public static Research[] GetSeedData()
        {
            return new Research[]
            {
            new Research
            {
                ResearchId = Guid.NewGuid(),
                Title = "Sample Research Title 1",
                Authors = "John Doe",
                PublicationDate = DateTime.Now,
                Summary = "Summary of the research article 1",
                FullTextLink = "http://example.com/research1",
                ThumbnailImage = "research1.jpg"
            },
            new Research
            {
                ResearchId = Guid.NewGuid(),
                Title = "Sample Research Title 2",
                Authors = "Jane Smith",
                PublicationDate = DateTime.Now,
                Summary = "Summary of the research article 2",
                FullTextLink = "http://example.com/research2",
                ThumbnailImage = "research2.jpg"
            }
            };
        }
    }

    public static class BlogSeed
    {
        public static Blog[] GetSeedData()
        {
            return new Blog[]
            {
            new Blog
            {
                BlogId = Guid.NewGuid(),
                Title = "Sample Blog Title 1",
                Author = "Alice Johnson",
                PublicationDate = DateTime.Now,
                Content = "Content of the blog post 1",
                ThumbnailImage = "blog1.jpg"
            },
            new Blog
            {
                BlogId = Guid.NewGuid(),
                Title = "Sample Blog Title 2",
                Author = "Bob Williams",
                PublicationDate = DateTime.Now,
                Content = "Content of the blog post 2",
                ThumbnailImage = "blog2.jpg"
            }
            };
        }
    }

    public static class FeaturedContentSeed
    {
        public static FeaturedContent[] GetSeedData()
        {
            return new FeaturedContent[]
            {
            new FeaturedContent
            {
                ContentId = Guid.NewGuid(),
                Title = "Sample Featured Content Title 1",
                Author = "Eva Brown",
                ContentType = "Blog",
                PublicationDate = DateTime.Now,
                Summary = "Summary of the featured content 1",
                FullContentLink = "http://example.com/featured1",
                ThumbnailImage = "featured1.jpg"
            },
            new FeaturedContent
            {
                ContentId = Guid.NewGuid(),
                Title = "Sample Featured Content Title 2",
                Author = "David Miller",
                ContentType = "Research",
                PublicationDate = DateTime.Now,
                Summary = "Summary of the featured content 2",
                FullContentLink = "http://example.com/featured2",
                ThumbnailImage = "featured2.jpg"
            }
            };
        }
    }

}
