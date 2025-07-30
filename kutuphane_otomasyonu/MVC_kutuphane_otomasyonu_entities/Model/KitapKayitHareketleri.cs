﻿using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Validator(typeof(KitapKayitHareketleriValidator))]

    public class KitapKayitHareketleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int KitapId { get; set; }
        public string YapilanIslem { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }

        public Kitaplar Kitaplar { get; set; }
    }
}
