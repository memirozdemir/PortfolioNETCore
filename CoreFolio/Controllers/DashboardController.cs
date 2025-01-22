using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.page = "Dashboard";
            ViewBag.page2 = "Dashboard";
            ViewBag.page3 = "Dashboard";
            return View();
        }
    }
}
