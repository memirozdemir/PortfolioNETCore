using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager scm = new SocialMediaManager(new EfSocialMediaDal()); 
        public IActionResult Index()
        {
            var values = scm.TGetList();
            return View(values);
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            scm.TAdd(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var value = scm.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(SocialMedia socialMedia)
        {
            socialMedia.Status = true;
            scm.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = scm.TGetByID(id);
            scm.TRemove(value);
            return RedirectToAction("Index");
        }
    }
}
