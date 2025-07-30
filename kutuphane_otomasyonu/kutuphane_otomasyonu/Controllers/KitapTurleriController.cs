using Microsoft.Ajax.Utilities;
using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyonu.Controllers
{
    [AllowAnonymous]

    public class KitapTurleriController : Controller
    {
        // GET: KitapTurleri
        KutuphaneContext context = new KutuphaneContext();
        KitapTurleriDAL KitapTurleriDAL = new KitapTurleriDAL();
        public ActionResult Index2(string ara,int ? page)
        {
            var model = KitapTurleriDAL.GetAll(context).ToPagedList(page ?? 1,3);
            if (ara != null)
            {
                model = KitapTurleriDAL.GetAll(context,x=>x.KitapTuru.Contains(ara)).ToPagedList(page ?? 1, 3);
            }
            return View("Index",model);
        }
        // bu kisim get icin kullanilir.
        public ActionResult Ekle()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]


        // bu kisim post islmei icin kullanilir ve dogrulama islemi yapilir. 
        public ActionResult Ekle(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)//model dogrulanirsa bu islemi gerceklestir
            {
                KitapTurleriDAL.InsertUpdate(context, kitapTurleri);
                KitapTurleriDAL.Save(context);
                return RedirectToAction("Index");//listelemededn sonra index sayfasina yonlendirecek.
            }
            return View(kitapTurleri);//model dogrulanmazas islem gerceklestirilmez
        }
       //burasi http get kismi icin 
        public ActionResult Duzenle(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var model=KitapTurleriDAL.GetById(context, id); 
            return View(model); 
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Duzenle(KitapTurleri kitapTurleri)
        {
            if (ModelState.IsValid)//model dogrulanirsa bu islemi gerceklestir
            {
                KitapTurleriDAL.InsertUpdate(context, kitapTurleri);
                KitapTurleriDAL.Save(context);
                return RedirectToAction("Index");//listelemededn sonra index sayfasina yonlendirecek.
            }
            return View(kitapTurleri);
        }
        public ActionResult Sil(int? id)
        {
            KitapTurleriDAL.Delete(context,x=>x.Id==id);
            KitapTurleriDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}