using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        public IActionResult Index()
        {
            ViewBag.page = "Hizmet";
            ViewBag.page2 = "Hizmetler";
            var values = serviceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.page = "Hizmet";
            ViewBag.page2 = "Hizmetler";
            ViewBag.page3 = "Düzenle";
            var value = serviceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Service service)
        {
            ViewBag.page = "Hizmet";
            ViewBag.page2 = "Hizmetler";
            ViewBag.page3 = "Düzenle";
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.page = "Hizmet";
            ViewBag.page2 = "Hizmetler";
            ViewBag.page3 = "Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Service service)
        {
            ViewBag.page = "Hizmet";
            ViewBag.page2 = "Hizmetler";
            ViewBag.page3 = "Ekle";
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = serviceManager.TGetByID(id);
            serviceManager.TRemove(value);
            return RedirectToAction("Index");
        }
    }
}
