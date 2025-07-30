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
    public class RollerMap : EntityTypeConfiguration<Roller>
    {
        public RollerMap()
        {
            this.ToTable("Roller");
            this.HasKey(x => x.Id);
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x=>x.Rol).IsRequired().HasMaxLength(100);

            
        }
    }
}
