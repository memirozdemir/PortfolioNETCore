using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Areas.Writer.Controllers
{
    [Authorize]
    [Area("Writer")]

    public class DefaultController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        public IActionResult Index()
        {
            var values = _announcementManager.TGetList();
            return View(values);
        }
        public IActionResult Details(int id)
        {
            Announcement announcement = _announcementManager.TGetByID(id);
            return View(announcement);
        }
    }
}
