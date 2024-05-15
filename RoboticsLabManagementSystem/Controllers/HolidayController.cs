using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboticsLabManagementSystem.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HolidayController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Holiday
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetHolidays()
        {
            return await _context.Holidays.ToListAsync();
        }

        // GET: api/Holiday/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holiday>> GetHoliday(Guid id)
        {
            var holiday = await _context.Holidays.FindAsync(id);

            if (holiday == null)
            {
                return NotFound();
            }

            return holiday;
        }

        // POST: api/Holiday
        [HttpPost]
        public async Task<ActionResult<Holiday>> PostHoliday(Holiday holiday)
        {
            _context.Holidays.Add(holiday);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHoliday), new { id = holiday.HolidayId }, holiday);
        }

        // DELETE: api/Holiday/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoliday(Guid id)
        {
            var holiday = await _context.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            _context.Holidays.Remove(holiday);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
