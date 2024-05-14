using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ResearchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Research
        [HttpGet("Research")]
        public async Task<ActionResult<IEnumerable<Research>>> GetResearches()
        {
            return await _context.Researches.ToListAsync();
        }

        // GET: api/Research
        [HttpGet("TopTwoResearchs")]
        public async Task<ActionResult<IEnumerable<Research>>> GetTopTwoResearches()
        {
            var topTwoResearchs = await _context.Researches.Take(2).ToListAsync();
            return topTwoResearchs;
        }


        // GET: api/Research/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Research>> GetResearch(Guid id)
        {
            var research = await _context.Researches.FindAsync(id);

            if (research == null)
            {
                return NotFound();
            }

            return research;
        }

        // POST: api/Research
        [HttpPost]
        public async Task<ActionResult<Research>> PostResearch(Research research)
        {
            _context.Researches.Add(research);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResearch), new { id = research.ResearchId }, research);
        }

        // PUT: api/Research/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearch(Guid id, Research research)
        {
            if (id != research.ResearchId)
            {
                return BadRequest();
            }

            _context.Entry(research).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchExists(id))
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

        // DELETE: api/Research/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearch(Guid id)
        {
            var research = await _context.Researches.FindAsync(id);
            if (research == null)
            {
                return NotFound();
            }

            _context.Researches.Remove(research);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchExists(Guid id)
        {
            return _context.Researches.Any(e => e.ResearchId == id);
        }
    }

}
