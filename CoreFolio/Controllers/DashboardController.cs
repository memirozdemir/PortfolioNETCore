using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewBag.page = "Dashboard";
            ViewBag.page2 = "Dashboard";
            ViewBag.page3 = "Dashboard";
            return View();
        }
    }
}
