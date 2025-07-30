using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class KitapKayitHareketleriValidator:AbstractValidator<KitapKayitHareketleri>
    {
        public KitapKayitHareketleriValidator()
        {
            RuleFor(x => x.YapilanIslem).MaximumLength(150).WithMessage("bu alan max 150 karakter icerebilir.");
            RuleFor(x => x.Aciklama).MaximumLength(600).WithMessage("bu alan max 600 karakter icerebilir.");
        }
    }
}
