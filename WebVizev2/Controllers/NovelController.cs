using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebVizev2.Models;

namespace WebVizev2.Controllers
{
    public class NovelController: Controller
    {

        public ActionResult Index()
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            List<Category> kategoriler = StatikVeritaban.KategoriListele;

            List<Novel> novellar= StatikVeritaban.NovelListele.ToList();
            return View(novellar);
        }
        public ActionResult Yorum(int id)
        {
            Novel novel= StatikVeritaban.DetayNovel(id);
            return PartialView(novel);
        }


        public ActionResult NovelSil(int id)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            StatikVeritaban.NovelSil(id);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult NovelEkle()
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;
            return View();
        }

        [HttpPost]
        public ActionResult NovelEkle(Novel novel)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            StatikVeritaban.NovelEkle(novel);
            return RedirectToAction("index");

        }

        [HttpGet]
        public ActionResult NovelGuncelle(int id)
        {
            Novel novel= StatikVeritaban.DetayNovel(id);
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;
            return View(novel);
        }

        [HttpPost]
        public ActionResult NovelGuncelle(Novel novel)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;

            StatikVeritaban.NovelGuncelle(novel);
            return RedirectToAction("index");

        }


        public ActionResult DetayNovel(int id)
        {
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;


            Novel novel= StatikVeritaban.DetayNovel(id);
            return View(novel);
        }

        [HttpPost]
        public ActionResult YorumEkle(Comment comment)
        {
            StatikVeritaban.YorumEkle(comment);
            return RedirectToAction("DetayNovel", new { id = comment.Novelid });
        }

        public ActionResult YorumSil(int id)
        {
            int novelid = 0;
            ViewBag.CategoryList = StatikVeritaban.KategoriListele;
            novelid = StatikVeritaban.YorumlaBul(id);
            StatikVeritaban.YorumSil(id);
            return RedirectToAction("DetayNovel", new { id = novelid });

        }
    }
}