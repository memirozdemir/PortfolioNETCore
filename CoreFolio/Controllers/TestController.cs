using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
