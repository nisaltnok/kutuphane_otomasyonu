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
    public class EmanetKitaplarMap:EntityTypeConfiguration<EmanetKitaplar>
    {
        public EmanetKitaplarMap()
        {
            this.ToTable("EmanetKitaplar");
            this.HasKey(x => x.Id); // Primary key
            this.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);//pk ve otomatik artan sayi

            this.HasRequired(x=>x.Kitaplar).WithMany(x=>x.EmanetKitaplar).HasForeignKey(x=>x.KitapId); //!! bu kisimi iyice anla
                                                                                                       //
            this.HasRequired(x=>x.Uyeler).WithMany(x=>x.EmanetKitaplar).HasForeignKey(x=>x.UyeId); //!! bu kisimi iyice anla 


        }
    }
}
