using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    public class EmanetKitaplarValidator:AbstractValidator<EmanetKitaplar>
    {
        public EmanetKitaplarValidator()
        {
            //RuleFor(x=>x.KitapId).NotEmpty().WithMessage("bu alan bos gecirilemez.")
        }
    }
}
