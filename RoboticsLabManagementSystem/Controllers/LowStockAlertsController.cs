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

        // GET: api/LowStockAlerts/Equipment
        //[HttpGet("Equipment")]
        //public IActionResult GetLowStockEquipment()
        //{
        //    var lowStockEquipment = _context.Equipment
        //        .Where(e => e.Quantity < e.Threshold.LowStockThreshold)
        //        .Include(e => e.Threshold); 
        //    return Ok(lowStockEquipment);
        //}

        //// GET: api/LowStockAlerts/PurchaseOrders
        //[HttpGet("PurchaseOrders")]
        //public IActionResult GetLowStockPurchaseOrders()
        //{
        //    var lowStockPurchaseOrders = _context.PurchaseOrders
        //        .Where(po => po.Quantity < po.Threshold.LowStockThreshold)
        //        .Include(po => po.Threshold); 
        //    return Ok(lowStockPurchaseOrders);
        //}
    }



}
