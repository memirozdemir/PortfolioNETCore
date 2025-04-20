using CoreFolio.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]

    public class RegisterController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;
        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser user = new WriterUser
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.Username,
                    ImageURL = p.ImageURL
                };
                if(p.Password == p.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(user, p.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
                
            return View();
        }
        //123456Aa*
    }
}
