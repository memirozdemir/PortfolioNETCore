using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index()
        {
            ViewBag.page = "Hakkımda";
            ViewBag.page2 = "Hakkımda";
            ViewBag.page3 = "Düzenle";
            var value = aboutManager.TGetByID(2);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            ViewBag.page = "Hakkımda";
            ViewBag.page2 = "Hakkımda";
            ViewBag.page3 = "Düzenle";
            aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
