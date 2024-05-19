using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchResultController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ResearchResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ResearchResult
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchResult>>> GetResearchResults()
        {
            return await _context.ResearchResults.Include(rr => rr.User).ToListAsync();
        }

        // GET: api/ResearchResult/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchResult>> GetResearchResult(int id)
        {
            var researchResult = await _context.ResearchResults.Include(rr => rr.User).FirstOrDefaultAsync(rr => rr.Id == id);

            if (researchResult == null)
            {
                return NotFound();
            }

            return researchResult;
        }

        // POST: api/ResearchResult
        [HttpPost]
        public async Task<ActionResult<ResearchResult>> PostResearchResult(ResearchResult researchResult)
        {
            _context.ResearchResults.Add(researchResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearchResult", new { id = researchResult.Id }, researchResult);
        }

        // PUT: api/ResearchResult/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchResult(int id, ResearchResult researchResult)
        {
            if (id != researchResult.Id)
            {
                return BadRequest();
            }

            _context.Entry(researchResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchResultExists(id))
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

        // DELETE: api/ResearchResult/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchResult(int id)
        {
            var researchResult = await _context.ResearchResults.FindAsync(id);
            if (researchResult == null)
            {
                return NotFound();
            }

            _context.ResearchResults.Remove(researchResult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchResultExists(int id)
        {
            return _context.ResearchResults.Any(e => e.Id == id);
        }
    }
}