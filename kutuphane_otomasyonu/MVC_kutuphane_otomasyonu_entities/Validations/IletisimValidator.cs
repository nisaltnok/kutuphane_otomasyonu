using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class IletisimValidator : AbstractValidator<Iletisim>
    {
        public IletisimValidator()
        {
            RuleFor(x => x.AdiSoyadi).NotEmpty().WithMessage("bu alan bos birakilamaz.");
            RuleFor(x => x.AdiSoyadi).MaximumLength(64).WithMessage("bu alan max 64 karakter icerebilir.");

            RuleFor(x => x.Mesaj).NotEmpty().WithMessage("bu alan bos birakilamaz.");
            RuleFor(x => x.Mesaj).MaximumLength(500).WithMessage("bu alan max 500 karakter icerebilir.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("bu alan bos birakilamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("lutfen bir email alani giriniz.");
            RuleFor(x => x.Email).MaximumLength(150).WithMessage("bu alan max 150 karakter icerebilir.");

            RuleFor(x => x.Baslik).NotEmpty().WithMessage("bu alan bos birakilamaz.");
            RuleFor(x => x.Baslik).MaximumLength(100).WithMessage("bu alan max 100 karakter icerebilir.");
            
            RuleFor(x => x.Aciklama).MaximumLength(5000).WithMessage("bu alan max 5000 karakter icerebilir.");
        }
    }
}
