using CoreFolio_API.DAL.ApiContext;
using CoreFolio_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryById(int id)
        {
            using var c = new Context();
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Categories.Add(p);
            c.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult CategoryUpdate(int id, Category p)
        {
            using var c = new Context();
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category.CategoryName = p.CategoryName;
                c.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                c.Categories.Remove(category);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
