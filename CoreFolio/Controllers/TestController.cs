using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
