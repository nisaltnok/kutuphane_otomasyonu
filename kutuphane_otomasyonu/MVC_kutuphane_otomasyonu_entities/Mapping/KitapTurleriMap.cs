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
    public class KitapTurleriMap:EntityTypeConfiguration<KitapTurleri>
    {
        public KitapTurleriMap()
        {
            this.ToTable("KitapTurleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.KitapTuru).IsRequired().HasMaxLength(150);
            this.Property(x => x.Aciklama).HasMaxLength(5000);
        }
    }
}
