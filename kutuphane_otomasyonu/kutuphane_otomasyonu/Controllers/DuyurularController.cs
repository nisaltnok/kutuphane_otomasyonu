using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace kutuphane_otomasyonu.Controllers
{
    public class DuyurularController : Controller
    {
        KutuphaneContext context = new KutuphaneContext();
        DuyurularDAL duyurularDAL = new DuyurularDAL();
        // GET: Duyurular
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DuyuruList()
        {
            var model = duyurularDAL.GetAll(context);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DuyuruEkle(Duyurular entity)  /* bu kisim calimyor kontrol et */
        {
            if (ModelState.IsValid)
            {
                duyurularDAL.InsertUpdate(context, entity);
                duyurularDAL.Save(context);
                return Json(new { success = true, message = "İşlem başarıyla gerçekleşti." });
            }

            var errors = ModelState.ToDictionary(
                x => x.Key,
                x => x.Value.Errors.Select(a => a.ErrorMessage).ToArray()
            );

            return Json(new { success = false, errors }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DuyuruGetir(int? Id)
        {
            var model = duyurularDAL.GetByFilter(context, x => x.Id == Id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DuyuruSil(int? Id)
        {
            duyurularDAL.Delete(context, x => x.Id == Id);
            return Json(new { success = true });
        }
        [HttpPost]
        public JsonResult SeciliDuyuruSil(List<int> selectedIds)
        {
            if (selectedIds != null)
            {
                foreach (int id in selectedIds)
                {
                    duyurularDAL.Delete(context, x => x.Id == id);
                    duyurularDAL.Save(context);
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

    }
}