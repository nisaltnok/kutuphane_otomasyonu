using MVC_kutuphane_otomasyonu_entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Mapping
{
    public class DuyurullarMap : EntityTypeConfiguration<Duyurular>

    {
        public DuyurullarMap()
        {
            this.ToTable("Duyurular");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // otomatik artan sayi 
            this.Property(x => x.Baslik).HasColumnType("varchar");                                 //kolonun turunu belirtir.
            this.Property(x => x.Baslik).IsRequired().HasMaxLength(150);            // is required kullanimi o kismin bos birakilamayacagni belitir. 
            this.Property(x => x.Duyuru).IsRequired().HasMaxLength(150); //hasmaxlengt maksimum karakter sayisini belirtir.
            this.Property(x => x.Aciklama).HasMaxLength(5000);

            this.Property(x => x.Id).HasColumnName("Id");//tablodaki bir sutunun ismini degistirmek istedigim zaman bunu kullanirim. 
        }

    }
}
