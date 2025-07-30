using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class KitaplarValidator:AbstractValidator<Kitaplar>
    {
        public KitaplarValidator()
        {
            RuleFor(x => x.BarkodNo).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.KitapTuruId).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.BarkodNo).MaximumLength(64).WithMessage("bu alan max 64 karakter icerilir.");

            RuleFor(x => x.KitapAdi).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.KitapAdi).MaximumLength(64).WithMessage("bu alan max 64 karakter icerilir.");

            RuleFor(x => x.YazarAdi).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.YazarAdi).MaximumLength(64).WithMessage("bu alan max 64 karakter icerilir.");

            RuleFor(x => x.YayinEvi).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.YayinEvi).MaximumLength(150).WithMessage("bu alan max 150 karakter icerilir.");

            RuleFor(x => x.Aciklama).MaximumLength(64).WithMessage("bu alan max 64 karakter icerilir.");


        }
    }
}
