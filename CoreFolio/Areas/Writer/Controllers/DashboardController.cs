using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreFolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            //weather api
            string api = "3d4500c2740cbdb47d6bd37aa713e886";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Ankara&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument doc = XDocument.Load(connection);
            string weather =doc.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            double temperature = Convert.ToDouble(weather);
            ViewBag.weather = (int)Math.Round(temperature);

            //statistics
            Context c = new Context();
            ViewBag.msg = c.WriterMessages.Where(x=>x.Receiver == values.Email).Count().ToString();
            ViewBag.announcement = c.Announcements.Count().ToString();
            ViewBag.users = c.Users.Count();
            ViewBag.skills = c.Skills.Count().ToString();
            return View();

        }
    }
}
