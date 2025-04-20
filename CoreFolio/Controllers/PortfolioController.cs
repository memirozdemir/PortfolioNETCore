using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolioDal());

        public IActionResult Index()
        {
            ViewBag.page = "Proje";
            ViewBag.page2 = "Projeler";
            var values = portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.page = "Proje";
            ViewBag.page2 = "Projeler";
            ViewBag.page3 = "Ekle";
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Portfolio portfolio)
        {
            ViewBag.page = "Proje";
            ViewBag.page2 = "Projeler";
            ViewBag.page3 = "Ekle";
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);
            
            if (results.IsValid)
            {
                portfolio.Status = true;
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var value = portfolioManager.TGetByID(id);
            portfolioManager.TRemove(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.page = "Proje";
            ViewBag.page2 = "Projeler";
            ViewBag.page3 = "Düzenle";
            var value = portfolioManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Portfolio portfolio)
        {
            ViewBag.page = "Proje";
            ViewBag.page2 = "Projeler";
            ViewBag.page3 = "Düzenle";
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if (results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
