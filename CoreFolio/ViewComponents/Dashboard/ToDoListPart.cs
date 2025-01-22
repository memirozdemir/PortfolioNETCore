using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.ViewComponents.Dashboard
{
    public class ToDoListPart:ViewComponent
    {
        ToDoListManager tdlm = new ToDoListManager(new EfToDoListDal());
        public IViewComponentResult Invoke()
        {
            var values = tdlm.TGetList();
            return View(values);
        }
    }
}
