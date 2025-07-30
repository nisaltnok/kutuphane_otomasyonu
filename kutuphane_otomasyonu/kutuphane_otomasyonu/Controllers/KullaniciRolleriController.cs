using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyonu.Controllers
{
    [AllowAnonymous]    /* 57 kismi*/
    public class KullaniciRolleriController : Controller
    {
        // GET: KullaniciRolleri

        KutuphaneContext context = new KutuphaneContext();
        KullaniciRolleriDAL kullaniciRolleriDAL = new KullaniciRolleriDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ekle(int? id)
        {
            if (id == null) { 
            return HttpNotFound("Kullanici degeri girilmedi.");
            }
            var model=kullaniciRolleriDAL.GetByFilter(context,x=>x.KullaniciId == id,"Kullanicilar");
            ViewBag.liste = new SelectList(context.Rollers, "Id","Rol");
            return View(model);
        }

        public ActionResult Sil(int id)
        {
            kullaniciRolleriDAL.Delete(context,x=>x.Id==id);
            kullaniciRolleriDAL.Save(context);
            return RedirectToAction("Index","Kullanicilar");
        }
    }
}