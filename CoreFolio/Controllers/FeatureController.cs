﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreFolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        public IActionResult Index()
        {
            ViewBag.page = "Öne Çıkan";
            ViewBag.page2 = "Öne Çıkanlar";
            ViewBag.page3 = "Düzenle";
            var values = featureManager.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            ViewBag.page = "Öne Çıkan";
            ViewBag.page2 = "Öne Çıkanlar";
            ViewBag.page3 = "Düzenle";
            featureManager.TUpdate(feature);
            return RedirectToAction("Index");
        }
    }
}
