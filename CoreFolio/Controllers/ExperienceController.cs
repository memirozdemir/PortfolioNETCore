using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            ViewBag.page = "Deneyim";
            ViewBag.page2 = "Deneyimler";
            var values = experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.page = "Deneyim";
            ViewBag.page2 = "Deneyimler";
            ViewBag.page3 = "Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.page = "Deneyim";
            ViewBag.page2 = "Deneyimler";
            ViewBag.page3 = "Düzenle";
            var value = experienceManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = experienceManager.TGetByID(id);
            experienceManager.TRemove(value);
            return RedirectToAction("Index");
        }
    }
}
