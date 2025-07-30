using FluentValidation.Attributes;
using MVC_kutuphane_otomasyonu_entities.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model
{
    [Validator(typeof(RollerValidator))]
    public class Roller
    {
        public int Id { get; set; }
        public string  Rol { get; set; }

        public List<KullaniciRolleri> KullaniciRolleri{ get; set; }
    }
}
