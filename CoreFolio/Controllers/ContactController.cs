using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    public class ContactController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageDal());
        public IActionResult Index()
        {
            var values = mm.TGetList();
            return View(values);
        }
        public IActionResult Delete(int id)
        {
            var value = mm.TGetByID(id);
            mm.TRemove(value);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
    }
}
