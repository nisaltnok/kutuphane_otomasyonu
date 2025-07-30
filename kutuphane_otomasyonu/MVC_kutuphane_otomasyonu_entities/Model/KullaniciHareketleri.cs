using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Validator(typeof(KullaniciHareketleriValidator))]

    public class KullaniciHareketleri
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public int IslemYapan {  get; set; }    
        public Kullanicilar kullanicilar { get; set; }
    }
}
