using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyonu.Controllers
{
    [AllowAnonymous]
    public class UyelerController : Controller
    {
        // GET: Uyeler
        KutuphaneContext context = new KutuphaneContext();
        UyelerDAL uyelerDAL = new UyelerDAL();
        public ActionResult Index()
        {
            var model = uyelerDAL.GetAll(context);
            return View(model); // Bu şekilde model gönderilmeli
        }


        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Ekle(Uyeler entity, HttpPostedFileBase ResimYolu)
        {
            if (ModelState.IsValid)
            {
                if (ResimYolu != null && ResimYolu.ContentLength > 0)
                {
                    var image = Path.GetFileName(ResimYolu.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        ResimYolu.SaveAs(path);
                    }
                    entity.ResimYolu = "/images/" + image;

                }
                uyelerDAL.InsertUpdate(context, entity);
                uyelerDAL.Save(context);
                return RedirectToAction("Index");

            }
            return View(entity);
        }

        public ActionResult Duzenle(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            var model = uyelerDAL.GetByFilter(context, x => x.Id == id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Duzenle(Uyeler entity, HttpPostedFileBase ResimYolu)
        {
            if (ModelState.IsValid)
            {
                var model = uyelerDAL.GetByFilter(context, x => x.Id == entity.Id);
                entity.ResimYolu = model.ResimYolu;
                if (ResimYolu != null && ResimYolu.ContentLength > 0)
                {
                    var image = Path.GetFileName(ResimYolu.FileName);
                    string path = Path.Combine(Server.MapPath("~/images"), image);
                    if (System.IO.File.Exists(path) == false)
                    {
                        ResimYolu.SaveAs(path);
                    }
                    entity.ResimYolu = "/images/" + image;

                }
                uyelerDAL.InsertUpdate(context, entity);
                uyelerDAL.Save(context);
                return RedirectToAction("Index");

            }
            return View(entity);
        }

        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            uyelerDAL.Delete(context,x=>x.Id == id);
            uyelerDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}