using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace CoreFolio.Controllers
{
    public class WriterUserController : Controller
    {
        WriterUserManager wum = new WriterUserManager(new EfWriterUserDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListUser() {
            var values = JsonConvert.SerializeObject(wum.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            wum.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
