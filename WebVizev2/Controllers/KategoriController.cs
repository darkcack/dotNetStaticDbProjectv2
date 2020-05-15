using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVizev2.Models;

namespace WebVizev2.Controllers
{
    public class KategoriController : Controller
    {
        public ActionResult KategoriIndex()
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            List<Category> kategoriler = StatikVeritaban.KategoriListele;
            return View(kategoriler);
        }

        [HttpPost]
        public ActionResult KategoriEkle(Category category)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            StatikVeritaban.KategoriEkle(category);
            return RedirectToAction("KategoriIndex");

        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;
            return View();
        }

        public ActionResult KategoriDetay(int id)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;
            ViewBag.katid = StatikVeritaban.KategoriBul(id);
            List<Novel> m = StatikVeritaban.KategoriDetay(id);
            return View(m);
        }

        public ActionResult KategoriSil(int id)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            StatikVeritaban.KategoriSil(id);
            return RedirectToAction("KategoriIndex");

        }
    }
}