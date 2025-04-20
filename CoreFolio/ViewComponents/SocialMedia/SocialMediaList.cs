using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SocialMediaManager scm = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values = scm.TGetList();
            return View(values);
        }
    }
}
