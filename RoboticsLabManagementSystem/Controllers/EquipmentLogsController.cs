using Microsoft.AspNetCore.Mvc;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EquipmentLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookItem(Guid userId, int equipmentId, DateTime endDate)
        {
            var item = await _context.Equipment.FindAsync(equipmentId);
            if (item == null || item.Quantity <= 0)
            {
                return BadRequest("Item is out of stock.");
            }

            item.Quantity--;
            _context.EquipmentLogs.Add(new EquipmentLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                EquipmentId = equipmentId,
                Action = "Book",
                ActionDate = DateTime.UtcNow,
                EndDate = endDate
            });

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPost("use")]
        public async Task<IActionResult> UseItem(Guid userId, int equipmentId)
        {
            var item = await _context.Equipment.FindAsync(equipmentId);
            if (item == null || item.Quantity <= 0)
            {
                return BadRequest("Item is out of stock.");
            }

            item.Quantity--;
            _context.EquipmentLogs.Add(new EquipmentLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                EquipmentId = equipmentId,
                Action = "Use",
                ActionDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnItem(Guid userId, int equipmentId)
        {
            var item = await _context.Equipment.FindAsync(equipmentId);
            if (item == null)
            {
                return NotFound();
            }

            item.Quantity++;
            _context.EquipmentLogs.Add(new EquipmentLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                EquipmentId = equipmentId,
                Action = "Return",
                ActionDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        [HttpPost("damage")]
        public async Task<IActionResult> DamageItem(Guid userId, int equipmentId)
        {
            var item = await _context.Equipment.FindAsync(equipmentId);
            if (item == null || item.Quantity <= 0)
            {
                return BadRequest("Item is out of stock.");
            }

            item.Quantity--;
            _context.EquipmentLogs.Add(new EquipmentLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                EquipmentId = equipmentId,
                Action = "Damage",
                ActionDate = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }
}

