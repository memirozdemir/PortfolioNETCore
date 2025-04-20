using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.page = "Yetenek";
            ViewBag.page2 = "Yetenekler";
            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Insert() 
        {
            ViewBag.page = "Yetenek";
            ViewBag.page2 = "Yetenekler";
            ViewBag.page3 = "Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = skillManager.TGetByID(id);
            skillManager.TRemove(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.page = "Yetenek";
            ViewBag.page2 = "Yetenekler";
            ViewBag.page3 = "Düzenle";
            var values = skillManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
