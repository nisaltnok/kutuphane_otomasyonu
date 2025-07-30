using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Validator(typeof(DuyurularValidator))]
    public class Duyurular
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Duyuru { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
