using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class RollerValidator:AbstractValidator<Roller>
    {
        public RollerValidator()
        {
            RuleFor(x => x.Rol).NotEmpty().WithMessage("bu alan bos gecirilemez.");
            RuleFor(x => x.Rol).MaximumLength(100).WithMessage("bu alan max 100 karakter icerebilir..");
        }
    }
}
