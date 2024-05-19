using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class LowStockAlertsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LowStockAlertsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("low-stock")]
        public async Task<IActionResult> GetLowStockItems()
        {
            var lowStockItems = await _context.Equipment
                                              .Where(e => e.Quantity < 5)
                                              .ToListAsync();

            return Ok(lowStockItems);
        }

    }



}
