using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
        public IActionResult Index()
        {
            var values = tm.TGetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value= tm.TGetByID(id);
            tm.TRemove(value);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var values = tm.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Testimonial p)
        {
            tm.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Testimonial p)
        {
            tm.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}
