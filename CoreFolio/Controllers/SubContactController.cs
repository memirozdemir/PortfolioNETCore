using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SubContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var value = cm.TGetByID(1);
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            cm.TUpdate(contact);
            return RedirectToAction("Index");
        }
    }
}
