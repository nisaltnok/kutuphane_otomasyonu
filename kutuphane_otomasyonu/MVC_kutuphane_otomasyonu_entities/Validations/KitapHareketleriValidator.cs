using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class KitapHareketleriValidator:AbstractValidator<KitapHareketleri>
    {
        public KitapHareketleriValidator()
        {
            RuleFor(x=>x.YapilanIslem).NotEmpty().WithMessage("bu alan bos birakilamaz.");
            RuleFor(x=>x.YapilanIslem).MaximumLength(150).WithMessage("bu alan max 150 karakter icerebilir.");
        }
    }
}
