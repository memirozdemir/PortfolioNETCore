using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.ViewComponents.Dashboard
{
    public class AdminNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
