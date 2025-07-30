using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_kutuphane_otomasyonu_entities.Model.ViewModel;

namespace kutuphane_otomasyonu.Controllers
{

    //[AllowAnonymous]   // calismazsa bu kismin yorum sarini kaldir.
    [Authorize(Roles = "Admin,Moderator")] // global tarafindaki kismi burada insanlarin girebilecegi hlae getiriyorum.
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        KutuphaneContext context = new KutuphaneContext();
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
        KullaniciRolleriDAL KullaniciRolleriDAL = new KullaniciRolleriDAL();
        RollerDAL rollerDal = new RollerDAL();
        KullaniciHareketleriDAL kullaniciHareketleriDAL = new KullaniciHareketleriDAL();

        public void KullaniciHareketleri(int kullaniciId, int islenYapanId, string aciklama)
        {
            var model = new KullaniciHareketleri
            {
                Aciklama = aciklama,
                IslemYapan = islenYapanId,
                KullaniciId = kullaniciId,
                Tarih = DateTime.Now,
            };
            kullaniciHareketleriDAL.InsertUpdate(context, model);
            kullaniciHareketleriDAL.Save(context);
        }
        public ActionResult Index()
        {
            var model = kullanicilarDAL.GetAll(context);
            return View(model);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            kullanicilarDAL.InsertUpdate(context, entity);
            kullanicilarDAL.Save(context);

            int kullaniciId = context.Kullanicilars.Max(x => x.Id);
            var userName = User.Identity.Name;
            var model = kullanicilarDAL.GetByFilter(context, x => x.Email == userName);
            var islemYapanId = model.Id;
            string aciklama = model.KullaniciAdi + "kullanici yeni bir kullanici ekledi";


            KullaniciHareketleri(kullaniciId, islemYapanId, aciklama);


            return RedirectToAction("Index2");
        }

        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound("id degeri girilmedi.");
            }

            var model = kullanicilarDAL.GetById(context, id);
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Duzenle(Kullanicilar entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }
            kullanicilarDAL.InsertUpdate(context, entity);
            kullanicilarDAL.Save(context);
            return RedirectToAction("Index2");
        }


        public ActionResult Index2()
        {
            var kullanicilar = kullanicilarDAL.GetAll(context, tbl: "KullaniciRolleri");
            var roller = rollerDal.GetAll(context);
            return View(new KullaniciRolViewModel { Kullanicilar = kullanicilar, Roller = roller });
        }

        public ActionResult KRolleri(int id)
        {
            var model = KullaniciRolleriDAL.GetAll(context, x => x.KullaniciId == id, "Roller");
            if (model != null)
            {
                return View(model);
            }
            return HttpNotFound();
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanicilar entity)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }

            var model = kullanicilarDAL.GetByFilter(context, x => x.Email == entity.Email && x.Sifre == entity.Sifre);
            if (model != null)// burasi == di != yapinca giris yapti 
            {
                FormsAuthentication.SetAuthCookie(entity.Email, false);



                int islemYapanId = model.Id;
                string aciklama = model.KullaniciAdi + "kullanici sisteme giris yapti.";

                KullaniciHareketleri(islemYapanId, islemYapanId, aciklama);





                return RedirectToAction("Index2", "KitapTurleri");/*burasi hata veirse index dize duzlet*/
            }
            ViewBag.error = "Kullanici adi veya sifre yanlis.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult KayitOl()
        {

            return View();
        }
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KayitOl(Kullanicilar entity, string sifreTekrar, bool kabul)
        {

            if (!ModelState.IsValid) //Model dogrulanmazsa
            {
                return View(entity);
            }
            else//Model Dogrulanirsa
            {
                if (entity.Sifre != sifreTekrar)//sifreler uyusmazsa
                {
                    ViewBag.sifreError = "Sifreler uyusmuyor.";
                    return View();
                }
                else//sifreler uyusursa
                {
                    if (!kabul)// sartlar kabul edilmemisse
                    {
                        ViewBag.kabulError = "Lutfen Sartlari Kabul Ettiniginizi Onaylayiniz!";
                        return View();
                    }
                    else//sartlar kabul edilmisse 
                    {
                        entity.KayitTarihi = DateTime.Now;
                        kullanicilarDAL.InsertUpdate(context, entity);
                        kullanicilarDAL.Save(context);

                        int kullaniciId = context.Kullanicilars.Max(x => x.Id);


                        string aciklama = "Yeni bir kullanici olusturuldu.";


                        KullaniciHareketleri(kullaniciId, kullaniciId, aciklama);
                        return RedirectToAction("Login");
                    }
                }
            }
        }
        [AllowAnonymous]

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SifremiUnuttum(Kullanicilar entity)
        {
            var model = kullanicilarDAL.GetByFilter(context, x => x.Email == entity.Email);

            if (model != null)
            {
                // Yeni rastgele şifre oluştur
                Guid rastgele = Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 8);
                kullanicilarDAL.Save(context);

                try
                {
                    SmtpClient client = new SmtpClient("smtp.outlook.com", 587);
                    client.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("muratakay123456@hotmail.com", "Kutuphane Sistemi");
                    mail.To.Add(model.Email);
                    mail.IsBodyHtml = true;
                    mail.Subject = "Şifre Değiştirme İsteği";
                    mail.Body += "Merhaba " + model.AdiSoyadi + "<br/>Kullanıcı Adınız: " + model.KullaniciAdi + "<br/>Yeni Şifreniz: " + model.Sifre;

                    // *** Gerçek şifre yerine uygulama parolası kullan ***
                    NetworkCredential net = new NetworkCredential("muratakay123456@hotmail.com", "UYGULAMA_PAROLASI_BURAYA");
                    client.Credentials = net;

                    client.Send(mail);

                    ViewBag.Success = "Yeni şifreniz e-posta adresinize gönderildi.";
                }
                catch (Exception ex)
                {
                    ViewBag.hata = "Mail gönderilirken bir hata oluştu: " + ex.Message;
                    return View();
                }
            }
            else if (entity.Email != null)
            {
                ViewBag.hata = "Böyle bir e-posta adresi bulunamadı.";
                return View();
            }

            return View();
        }

    }
}

