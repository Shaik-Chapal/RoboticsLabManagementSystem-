using Microsoft.AspNetCore.Mvc;
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
    }
}
