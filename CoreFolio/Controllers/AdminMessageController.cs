using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager wmm = new WriterMessageManager(new EfWriterMessageDal());
        UserManager<WriterUser> _userManager;
        public IActionResult Inbox()
        {
            string p = "emremr1123@gmail.com";
            var values = wmm.GetListReceivedMessage(p);
            return View(values);
        }
        public IActionResult Sentbox()
        {
            string p = "emremr1123@gmail.com";
            var values = wmm.GetListSendedMessage(p);
            return View(values);
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(WriterMessage writerMessage)
        {
            string mail = "emremr1123@gmail.com";
            string name = "Mehmet Emir Özdemir";
            writerMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            writerMessage.Sender = mail;
            writerMessage.SenderName = name;
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName = usernamesurname;
            wmm.TAdd(writerMessage);
            return RedirectToAction("Sentbox");
        }

    }
}
