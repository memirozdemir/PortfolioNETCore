﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Areas.Writer.ViewComponents
{
    public class Navbar:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user.ImageURL;
            return View(user);
        }
    }
}
