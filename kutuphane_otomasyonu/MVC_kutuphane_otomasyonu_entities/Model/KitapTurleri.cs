using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Table("Kitap Turleri")]
    [Validator(typeof(KitapTurleriValidator))]
    public class KitapTurleri
    {
        public int Id { get; set; }
       
        public string KitapTuru { get; set; }
        public string Aciklama { get; set; }
        public List<Kitaplar> Kitaplar { get; set; } //cogul adlandirma; bir kitap turunde birden fazla kitap olabilir. 
    }
}
