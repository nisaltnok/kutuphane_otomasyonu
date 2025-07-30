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
    public class KitapHareketleriMap : EntityTypeConfiguration<KitapHareketleri>
    {
        public KitapHareketleriMap()
        {
            this.ToTable("KitapHareketleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.YapilanIslem).IsRequired().HasMaxLength(150);

            this.HasRequired(x=>x.Kitaplar).WithMany(x=>x.KitapHareketleri).HasForeignKey(x=>x.KitapId);
        }
    }
}
