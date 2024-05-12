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

        // GET: api/v1/PurchaseOrder
        [HttpGet]
        public IActionResult GetAllPurchaseOrders()
        {
            var purchaseOrders = _dbContext.PurchaseOrders.ToList();
            return Ok(purchaseOrders);
        }

        // GET: api/v1/PurchaseOrder/{id}
        [HttpGet("{id}")]
        public IActionResult GetPurchaseOrderById(Guid id)
        {
            var purchaseOrder = _dbContext.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            return Ok(purchaseOrder);
        }

        // POST: api/v1/PurchaseOrder
        [HttpPost]
        public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.PurchaseOrders.Add(purchaseOrder);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetPurchaseOrderById), new { id = purchaseOrder.PurchaseOrderId }, purchaseOrder);
        }

        // PUT: api/v1/PurchaseOrder/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePurchaseOrder(Guid id, [FromBody] PurchaseOrder updatedPurchaseOrder)
        {
            if (id != updatedPurchaseOrder.PurchaseOrderId)
            {
                return BadRequest();
            }
            _dbContext.Entry(updatedPurchaseOrder).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return NoContent();
        }

        // DELETE: api/v1/PurchaseOrder/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePurchaseOrder(Guid id)
        {
            var purchaseOrder = _dbContext.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            _dbContext.PurchaseOrders.Remove(purchaseOrder);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }

}
