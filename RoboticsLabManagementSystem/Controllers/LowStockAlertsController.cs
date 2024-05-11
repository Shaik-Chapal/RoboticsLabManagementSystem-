using Microsoft.AspNetCore.Mvc;

namespace RoboticsLabManagementSystem.Controllers
{
    public class LowStockAlertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
