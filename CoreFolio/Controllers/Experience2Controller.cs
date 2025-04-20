using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace CoreFolio.Controllers
{
    public class Experience2Controller : Controller
    {
        ExperienceManager em = new ExperienceManager(new EfExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(em.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            em.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetByID(int ExperienceID)
        {
            var values = JsonConvert.SerializeObject(em.TGetByID(ExperienceID));
            return Json(values);
        }
        public IActionResult DeleteExperience(int ExperienceID)
        {
            var v = em.TGetByID(ExperienceID);
            em.TRemove(v);
            return NoContent();
        }
    }
}
