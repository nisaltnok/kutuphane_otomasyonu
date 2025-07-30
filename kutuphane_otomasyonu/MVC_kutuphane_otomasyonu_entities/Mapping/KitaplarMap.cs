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
    public class KitaplarMap : EntityTypeConfiguration<Kitaplar>
    {
        public KitaplarMap()
        {
            this.ToTable("Kitaplar");
            this.HasKey(x=>x.Id);
            this.Property(x=>x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x=>x.BarkodNo).IsRequired().HasMaxLength(64);
            this.Property(x=>x.KitapAdi).IsRequired().HasMaxLength(64);
            this.Property(x=>x.YazarAdi).IsRequired().HasMaxLength(64);
            this.Property(x=>x.YayinEvi).IsRequired().HasMaxLength(150);
            this.Property(x=>x.Aciklama).HasMaxLength(5000);

            this.HasRequired(x=>x.KitapTurleri).WithMany(x=>x.Kitaplar).HasForeignKey(x=>x.KitapTuruId);//iliskilendime yapiliyor. burada kitap turleri kitaplara baglaniyor. 
        }
    }
}
