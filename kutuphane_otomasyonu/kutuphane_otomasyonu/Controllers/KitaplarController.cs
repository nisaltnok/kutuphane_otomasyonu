using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using MVC_kutuphane_otomasyonu_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_kutuphane_otomasyonu_entities.Model;

namespace kutuphane_otomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class KitaplarController : Controller
    {
        // GET: Kitaplar
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL KitaplarDAL = new KitaplarDAL();
        KitapKayitHareketleriDAL kitapKayitHareketleriDAL = new KitapKayitHareketleriDAL();
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();

        public void KitapKayitHareketleri(int kullaniciId, int kitapId, string YapilanIslem, string aciklama)
        {
            var model = new KitapKayitHareketleri
            {
                Aciklama = aciklama,
                KullaniciId = kullaniciId,
                KitapId = kitapId,
                YapilanIslem = YapilanIslem,
                Tarih = DateTime.Now,
            };
            kitapKayitHareketleriDAL.InsertUpdate(context, model);
            kitapKayitHareketleriDAL.Save(context);
        }





        public ActionResult Index(KitaplarDAL KitaplarDAL)
        {
            var model = KitaplarDAL.GetAll(context, null, "KitapTurleri");
            return View(model);
        }
        public ActionResult Ekle()
        {
            ViewBag.liste = new SelectList(context.kitapTurleris, "Id", "KitapTuru");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ekle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.kitapTurleris, "Id", "KitapTuru");
                return View(entity);
            }
            KitaplarDAL.InsertUpdate(context, entity);
            KitaplarDAL.Save(context);

            int kitapId = context.kitaplars.Max(x => x.Id);
            var userName = User.Identity.Name;
            var modelKullanici = kullanicilarDAL.GetByFilter(context, x => x.Email == userName);
            int kullaniciId = modelKullanici.Id;
            KitapKayitHareketleri(kullaniciId, kitapId, modelKullanici.KullaniciAdi + " kullanicisi yeni bir kitap ekledi.", " Kitap ekleme isi");



            return RedirectToAction("Index");
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            ViewBag.liste = new SelectList(context.kitapTurleris, "Id", "KitapTuru");
            var model = KitaplarDAL.GetByFilter(context, x => x.Id == id, "KitapTurleri");
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Duzenle(Kitaplar entity)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.liste = new SelectList(context.kitapTurleris, "Id", "KitapTuru");
                return View(entity);
            }
            KitaplarDAL.InsertUpdate(context, entity);
            KitaplarDAL.Save(context);

            int kitapId = entity.Id;
            var userName = User.Identity.Name;
            var modelKullanici = kullanicilarDAL.GetByFilter(context, x => x.Email == userName);
            int kullaniciId = modelKullanici.Id;
            KitapKayitHareketleri(kullaniciId, kitapId, modelKullanici.KullaniciAdi + " kullanicisi kitap uzerinde degisiklik gerceklestirdi.", " Kitap duzeltme islemi.");



            return RedirectToAction("Index");
        }
        public ActionResult Detay(int? id)
        {
            var model = KitaplarDAL.GetByFilter(context, x => x.Id == id, "KitapTurleri");
            return View(model);
        }
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            KitaplarDAL.Delete(context, x => x.Id == id);
            KitaplarDAL.Save(context);
            return RedirectToAction("Index");
        }
    }
}