using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Infrastructure;

namespace RoboticsLabManagementSystem.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PurchaseOrderController> _logger;

        public PurchaseOrderController(ApplicationDbContext dbContext, ILogger<PurchaseOrderController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPurchaseOrders()
        {
            var purchaseOrders = await _dbContext.PurchaseOrders.ToListAsync();
            return Ok(purchaseOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseOrder(Guid id)
        {
            var purchaseOrder = await _dbContext.PurchaseOrders.FindAsync(id);

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return Ok(purchaseOrder);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] PurchaseOrderDto purchaseOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipment = await _dbContext.Equipment.FindAsync(purchaseOrderDto.EquipmentId);

            if (equipment == null)
            {
                return NotFound("Associated equipment not found");
            }

            // Create a PurchaseOrder object from the DTO
            var purchaseOrder = new PurchaseOrder
            {
                ItemName = purchaseOrderDto.ItemName,
                Quantity = purchaseOrderDto.Quantity,
                ExpirationDate = purchaseOrderDto.ExpirationDate,
                Price = purchaseOrderDto.Price,
                EquipmentId = purchaseOrderDto.EquipmentId,
                Company = purchaseOrderDto.Company,
                Origin = purchaseOrderDto.Origin,
                Manufacturer = purchaseOrderDto.Manufacturer,
                ModelNumber = purchaseOrderDto.ModelNumber,
                CreateDate = purchaseOrderDto.CreateDate
            };

            // Update the quantity of the associated equipment
            equipment.Quantity += purchaseOrder.Quantity;

            // Associate the equipment with the purchase order
            purchaseOrder.Equipment = equipment;

            _dbContext.PurchaseOrders.Add(purchaseOrder);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPurchaseOrder), new { id = purchaseOrder.PurchaseOrderId }, purchaseOrder);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePurchaseOrder(Guid id, [FromBody] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.PurchaseOrderId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var existingPurchaseOrder = await _dbContext.PurchaseOrders.FindAsync(id);
            if (existingPurchaseOrder == null)
            {
                return NotFound();
            }

            // Adjust the quantity of the associated equipment
            var equipment = await _dbContext.Equipment.FindAsync(purchaseOrder.EquipmentId);
            if (equipment == null)
            {
                return NotFound("Associated equipment not found");
            }

            // Revert the old quantity update and apply the new one
            equipment.Quantity -= existingPurchaseOrder.Quantity;
            equipment.Quantity += purchaseOrder.Quantity;

            _dbContext.Entry(existingPurchaseOrder).CurrentValues.SetValues(purchaseOrder);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseOrder(Guid id)
        {
            var purchaseOrder = await _dbContext.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            var equipment = await _dbContext.Equipment.FindAsync(purchaseOrder.EquipmentId);
            if (equipment != null)
            {
                equipment.Quantity -= purchaseOrder.Quantity;
            }

            _dbContext.PurchaseOrders.Remove(purchaseOrder);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }

}
