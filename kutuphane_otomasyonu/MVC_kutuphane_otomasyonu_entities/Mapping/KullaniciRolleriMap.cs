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
    public class KullaniciRolleriMap : EntityTypeConfiguration<KullaniciRolleri>
    {
        public KullaniciRolleriMap()
        {
            this.ToTable("KullaniciRolleri");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasRequired(x=>x.Kullanicilar).WithMany(x=>x.KullaniciRolleri).HasForeignKey(x=>x.KullaniciId);
            this.HasRequired(x=>x.Roller).WithMany(x=>x.KullaniciRolleri).HasForeignKey(x=>x.RolId);
        }
    }
}
