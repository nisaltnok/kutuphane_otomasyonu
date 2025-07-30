using FluentValidation;
using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Validations
{
    /// <summary>
    /// bu kisimda ilgili bolgelerdeki sinirlandirmalari yapiyoruz.
    /// validation= dogrulama
    /// </summary>
    public class DuyurularValidator : AbstractValidator<Duyurular>
    {
        public DuyurularValidator()
        {
            RuleFor(x => x.Baslik).NotEmpty().WithMessage("Baslik alani bos gecirilemez.");
            RuleFor(x => x.Duyuru).NotEmpty().WithMessage("Duyuru alani bos gecirilemez.");
            RuleFor(x => x.Tarih).NotEmpty().WithMessage("Tarih alani bos gecirilemez.");
            RuleFor(x => x.Baslik).Length(5, 150).WithMessage("baslik alani 5-150 karakter arasinda olmalidir.");//5 karakter ve 150 karkater arasinda kullanim 
            RuleFor(x => x.Duyuru).MaximumLength(500).WithMessage("duyuru alani 500 karakterden fazla iceremez.");//5 karakter ve 150 karkater arasinda kullanim 
            //RuleFor(x => x.Aciklama).MaximumLength(500).WithMessage("aciklama alani 500 karakterden fazla iceremez.");//5 karakter ve 150 karkater arasinda kullanim 
        //    RuleFor(x => x.Baslik).MaximumLength(150).WithMessage("baslik alani max 150 karakter olmalidir.");//5 karakter ve 150 karkater arasinda kullanim 
        //    RuleFor(x => x.Baslik).MinimumLength(5).WithMessage("baslik alani min 5 karakter olmalidir.");//5 karakter ve 150 karkater arasinda kullanim 

        }
    }
}
