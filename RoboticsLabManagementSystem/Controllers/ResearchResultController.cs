using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ResearchResult>>> GetResearchResultsByUserId(Guid userId)
        {
            var researchResults = await _context.ResearchResults
                                                .Where(rr => rr.UserId == userId)
                                                .ToListAsync();

            if (!researchResults.Any())
            {
                return NotFound();
            }

            return researchResults;
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
        [HttpPost]
        public async Task<ActionResult<ResearchResult>> PostResearchResult(ResearchResultModel researchResultModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the user from the database using the UserId
            var user = await _context.Users.FindAsync(researchResultModel.UserId);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Convert the model to the entity and set the User property
            var researchResult = new ResearchResult
            {
                Topic = researchResultModel.Topic,
                Introduction = researchResultModel.Introduction,
                Abstract = researchResultModel.Abstract,
                Methodology = researchResultModel.Methodology,
                Description = researchResultModel.Description,
                Result = researchResultModel.Result,
                Conclusion = researchResultModel.Conclusion,
                UserId = researchResultModel.UserId,
                User = user
            };

            // Log or inspect researchResult
            Console.WriteLine($"Received ResearchResult: {JsonConvert.SerializeObject(researchResult)}");

            _context.ResearchResults.Add(researchResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearchResult", new { id = researchResult.Id }, researchResult);
        }



        // PUT: api/ResearchResult/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchResult(int id, ResearchResultModel researchResultModel)
        {
            if (id != researchResultModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the existing research result from the database
            var researchResult = await _context.ResearchResults.Include(rr => rr.User).FirstOrDefaultAsync(rr => rr.Id == id);
            if (researchResult == null)
            {
                return NotFound();
            }

            // Ensure the user exists
            var user = await _context.Users.FindAsync(researchResultModel.UserId);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            // Update the properties of the existing research result
            researchResult.Topic = researchResultModel.Topic;
            researchResult.Introduction = researchResultModel.Introduction;
            researchResult.Abstract = researchResultModel.Abstract;
            researchResult.Methodology = researchResultModel.Methodology;
            researchResult.Description = researchResultModel.Description;
            researchResult.Result = researchResultModel.Result;
            researchResult.Conclusion = researchResultModel.Conclusion;
            researchResult.UserId = researchResultModel.UserId;
            researchResult.User = user;

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