using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    public interface IResearchService
    {
        Task<IEnumerable<Research>> GetResearchesAsync();
        Task<IEnumerable<Research>> GetTopTwoResearchesAsync();
        Task<Research> GetResearchByIdAsync(Guid id);
        Task<Research> CreateResearchAsync(Research research);
        Task<bool> UpdateResearchAsync(Guid id, Research research);
        Task<bool> DeleteResearchAsync(Guid id);
    }
    public class ResearchService : IResearchService
    {
        private readonly ApplicationDbContext _context;

        public ResearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Research>> GetResearchesAsync()
        {
            return await _context.Researches.ToListAsync();
        }

        public async Task<IEnumerable<Research>> GetTopTwoResearchesAsync()
        {
            return await _context.Researches.Take(2).ToListAsync();
        }

        public async Task<Research> GetResearchByIdAsync(Guid id)
        {
            return await _context.Researches.FindAsync(id);
        }

        public async Task<Research> CreateResearchAsync(Research research)
        {
            _context.Researches.Add(research);
            await _context.SaveChangesAsync();
            return research;
        }

        public async Task<bool> UpdateResearchAsync(Guid id, Research research)
        {
            if (id != research.ResearchId)
            {
                return false;
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
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteResearchAsync(Guid id)
        {
            var research = await _context.Researches.FindAsync(id);
            if (research == null)
            {
                return false;
            }

            _context.Researches.Remove(research);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ResearchExists(Guid id)
        {
            return _context.Researches.Any(e => e.ResearchId == id);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ResearchController : ControllerBase
    {
        private readonly IResearchService _researchService;

        public ResearchController(IResearchService researchService)
        {
            _researchService = researchService ?? throw new ArgumentNullException(nameof(researchService));
        }

        [HttpGet("Research")]
        public async Task<ActionResult<IEnumerable<Research>>> GetResearches()
        {
            var researches = await _researchService.GetResearchesAsync();
            return Ok(researches);
        }

        [HttpGet("TopTwoResearchs")]
        public async Task<ActionResult<IEnumerable<Research>>> GetTopTwoResearches()
        {
            var topTwoResearches = await _researchService.GetTopTwoResearchesAsync();
            return Ok(topTwoResearches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Research>> GetResearch(Guid id)
        {
            var research = await _researchService.GetResearchByIdAsync(id);
            if (research == null)
            {
                return NotFound();
            }
            return Ok(research);
        }

        [HttpPost]
        public async Task<ActionResult<Research>> CreateResearch(Research research)
        {
            if (research == null)
            {
                return BadRequest();
            }

            var createdResearch = await _researchService.CreateResearchAsync(research);
            return CreatedAtAction(nameof(GetResearch), new { id = createdResearch.ResearchId }, createdResearch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResearch(Guid id, Research research)
        {
            if (id != research.ResearchId)
            {
                return BadRequest();
            }

            var result = await _researchService.UpdateResearchAsync(id, research);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearch(Guid id)
        {
            var result = await _researchService.DeleteResearchAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
