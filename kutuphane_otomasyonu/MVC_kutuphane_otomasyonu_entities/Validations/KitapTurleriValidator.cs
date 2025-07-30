using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class KitapTurleriValidator:AbstractValidator<KitapTurleri>
    {
        public KitapTurleriValidator()
        {
            RuleFor(x => x.KitapTuru).NotEmpty().WithMessage("bu alan bos birakilmaz.");
            RuleFor(x => x.KitapTuru).MinimumLength(5).WithMessage("bu alan 5 karakterden az olamaz.");
            RuleFor(x => x.KitapTuru).MaximumLength(150).WithMessage("bu alan bos birakilmaz.");
        }
    }
}
