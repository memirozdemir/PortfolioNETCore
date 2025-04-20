using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.ViewComponents.Dashboard
{
    public class NavbarMessage:ViewComponent
    {
        WriterMessageManager wmm = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string p  = "emremr1123@gmail.com";
            var values = wmm.GetListReceivedMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();
            return View(values);
        }
    }
}
