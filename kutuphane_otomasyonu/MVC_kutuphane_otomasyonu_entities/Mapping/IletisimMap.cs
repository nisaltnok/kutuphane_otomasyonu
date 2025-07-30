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
    public class IletisimMap:EntityTypeConfiguration<Iletisim>
    {
        public IletisimMap()
        {
            this.ToTable("Iletisim");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x=>x.AdiSoyadi).IsRequired().HasMaxLength(64);
            this.Property(x=>x.Mesaj).IsRequired().HasMaxLength(500);
            this.Property(x=>x.Email).IsRequired().HasMaxLength(150);
            this.Property(x=>x.Baslik).IsRequired().HasMaxLength(100);
            this.Property(x=>x.Aciklama).HasMaxLength(5000);
           
        }
    }
}
