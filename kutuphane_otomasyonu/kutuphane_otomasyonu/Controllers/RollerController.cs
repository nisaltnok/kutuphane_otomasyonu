using MVC_kutuphane_otomasyonu_entities.DataAccessLayer;
using MVC_kutuphane_otomasyonu_entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kutuphane_otomasyonu.Controllers
{
    [AllowAnonymous]
    public class RollerController : Controller
    {
        // GET: Roller
        KutuphaneContext context=new KutuphaneContext();
        RollerDAL rollerDAL = new RollerDAL();
        public ActionResult Index()
        {
            var model=rollerDAL.GetAll(context);
            return View();
        }
    }
}