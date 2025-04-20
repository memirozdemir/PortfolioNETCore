using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
    }
}
