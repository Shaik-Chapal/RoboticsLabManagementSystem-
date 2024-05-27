using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using RoboticsLabManagementSystem.Dto;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BranchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
        {
            return await _context.Branch.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Branch>> GetBranch(Guid id)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return branch;
        }

        [HttpPost]
        public async Task<ActionResult<Branch>> CreateBranch(BranchDto branchDto)
        {
            if (await _context.Branch.AnyAsync(b => b.Name == branchDto.Name && b.CompanyId == branchDto.CompanyId))
            {
                return Conflict("Branch name already exists for this company.");
            }

            var branch = new Branch
            {
                Id = Guid.NewGuid(),
                Name = branchDto.Name,
                Address = branchDto.Address,
                Phone = branchDto.Phone,
                CompanyId = branchDto.CompanyId
            };

            _context.Branch.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBranch), new { id = branch.Id }, branch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBranch(Guid id, BranchDto branchDto)
        {
            if (await _context.Branch.AnyAsync(b => b.Name == branchDto.Name))
            {
                return Conflict("Branch name already exists for this company.");
            }
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            if (await _context.Branch.AnyAsync(b => b.Name == branchDto.Name && b.CompanyId == branchDto.CompanyId && b.Id != id))
            {
                return Conflict("Branch name already exists for this company.");
            }

            branch.Name = branchDto.Name;
            branch.Address = branchDto.Address;
            branch.Phone = branchDto.Phone;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(Guid id)
        {
            var branch = await _context.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branch.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
