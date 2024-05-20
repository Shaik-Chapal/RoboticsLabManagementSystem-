using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentLogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EquipmentLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> LogEquipmentUsage([FromBody] EquipmentLogRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipmentLog = new EquipmentLog
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Action = request.Action,
                Approval = request.Approval,
                ActionDate = DateTime.UtcNow,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Items = request.Items.Select(item => new EquipmentLogItem
                {
                    EquipmentId = item.EquipmentId,
                    Quantity = item.Quantity
                }).ToList()
            };

            foreach (var item in equipmentLog.Items)
            {
                var equipment = await _context.Equipment.FindAsync(item.EquipmentId);
                if (equipment == null)
                {
                    return NotFound($"Equipment with ID {item.EquipmentId} not found.");
                }

                switch (request.Action.ToLower())
                {
                    case "book":
                    case "use":
                        if (equipment.Quantity < item.Quantity)
                        {
                            return BadRequest($"Not enough quantity for equipment ID {item.EquipmentId}. Available: {equipment.Quantity}, Requested: {item.Quantity}");
                        }
                        equipment.Quantity -= item.Quantity;
                        break;
                    case "return":
                        equipment.Quantity += item.Quantity;
                        break;
                    case "damage":
                        if (equipment.Quantity < item.Quantity)
                        {
                            return BadRequest($"Not enough quantity for equipment ID {item.EquipmentId}. Available: {equipment.Quantity}, Reported Damage: {item.Quantity}");
                        }
                        equipment.Quantity -= item.Quantity;
                        break;
                    default:
                        return BadRequest("Invalid action. Allowed actions are: Book, Use, Return, Damage.");
                }

                _context.Equipment.Update(equipment);
            }

            _context.EquipmentLogs.Add(equipmentLog);
            await _context.SaveChangesAsync();

            return Ok(equipmentLog);
           
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentLog>>> GetEquipmentLogs()
        {
            var equipmentLogs = await _context.EquipmentLogs
                                              .Include(el => el.Items)
                                              .ToListAsync();
            return Ok(equipmentLogs);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<EquipmentLog>>> GetEquipmentLogsByUserId(Guid userId)
        {
            var equipmentLogs = await _context.EquipmentLogs
                                              .Where(el => el.UserId == userId)
                                              .Include(el => el.Items)
                                              .ToListAsync();
            if (!equipmentLogs.Any())
            {
                return NotFound();
            }
            return Ok(equipmentLogs);
        }

        [HttpPut("{id}/approval")]
        public async Task<IActionResult> UpdateApprovalStatus(Guid id, [FromBody] UpdateApprovalRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipmentLog = await _context.EquipmentLogs.FindAsync(id);
            if (equipmentLog == null)
            {
                return NotFound();
            }

            equipmentLog.Approval = request.Approval;

            _context.Entry(equipmentLog).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.EquipmentLogs.Any(e => e.Id == id))
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

    }
    public class UpdateApprovalRequest
    {
        public int Approval { get; set; }
    }

}