using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class HakkimizdaValidator:AbstractValidator<Hakkimizda>
    {
        public HakkimizdaValidator()
        {
            RuleFor(x => x.Icerik).NotEmpty().WithMessage("icerik alani bos gecirilemez");
            RuleFor(x => x.Icerik).MaximumLength(500).WithMessage("icerik alani max 500 karakter icerebilir.");
        }
    }
}
