using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedContentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeaturedContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FeaturedContent
        [HttpGet("FeaturedContents")]
        public async Task<ActionResult<IEnumerable<FeaturedContent>>> GetFeaturedContents()
        {
            return await _context.FeaturedContents.ToListAsync();
        }


        // GET: api/FeaturedContents
        [HttpGet("TopTwoFeaturedContents")]
        public async Task<ActionResult<IEnumerable<FeaturedContent>>> GetTopTwoFeaturedContentes()
        {
            var topTwoFeaturedContents = await _context.FeaturedContents.Take(2).ToListAsync();
            return topTwoFeaturedContents;
        }


        // GET: api/FeaturedContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeaturedContent>> GetFeaturedContent(Guid id)
        {
            var featuredContent = await _context.FeaturedContents.FindAsync(id);

            if (featuredContent == null)
            {
                return NotFound();
            }

            return featuredContent;
        }

        // POST: api/FeaturedContent
        [HttpPost]
        public async Task<ActionResult<FeaturedContent>> PostFeaturedContent(FeaturedContent featuredContent)
        {
            _context.FeaturedContents.Add(featuredContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeaturedContent), new { id = featuredContent.ContentId }, featuredContent);
        }

        // PUT: api/FeaturedContent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeaturedContent(Guid id, FeaturedContent featuredContent)
        {
            if (id != featuredContent.ContentId)
            {
                return BadRequest();
            }

            _context.Entry(featuredContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeaturedContentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/FeaturedContent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeaturedContent(Guid id)
        {
            var featuredContent = await _context.FeaturedContents.FindAsync(id);
            if (featuredContent == null)
            {
                return NotFound();
            }

            _context.FeaturedContents.Remove(featuredContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeaturedContentExists(Guid id)
        {
            return _context.FeaturedContents.Any(e => e.ContentId == id);
        }
    }

}
