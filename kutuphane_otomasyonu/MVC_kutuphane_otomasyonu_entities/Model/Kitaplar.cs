﻿using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Validator(typeof(KitaplarValidator))]

    public class Kitaplar
    {
        public int Id { get; set; }
        public string BarkodNo { get; set; }
        public int KitapTuruId { get; set; }
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string YayinEvi { get; set; }
        public int StokAdedi { get; set; }
        public int SayfaSayisi { get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public DateTime GuncellenmeTarihi { get; set; } = DateTime.Now;
        public bool SilindiMi { get; set; } = false;
        public KitapTurleri KitapTurleri { get; set; }  //1-n yapilandirma bir kitabin bir turu olabilir. //TEKIL adlandirma
        //public object KitapTuruId { get; internal set; }

        public List<EmanetKitaplar> EmanetKitaplar { get; set; }
        public List<KitapHareketleri> KitapHareketleri { get; set; }

        public List<KitapKayitHareketleri> KitapKayitHareketleri { get; set; }
    }
}
