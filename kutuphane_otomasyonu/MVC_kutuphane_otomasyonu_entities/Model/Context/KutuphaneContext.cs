using MVC_kutuphane_otomasyonu_entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_kutuphane_otomasyonu_entities.Model.Context
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext() : base("Kutuphane")//yapici metot nedir arastir 
        {



        }
        //bu kisimi iyi arastir
        public DbSet<Duyurular> Duyurulars { get; set; }
        public DbSet<EmanetKitaplar> EmanetKitaplars { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<KitapKayitHareketleri> KitapKayitHareketleris { get; set; }
        public DbSet<Kitaplar> kitaplars { get; set; }
        public DbSet<KitapTurleri> kitapTurleris { get; set; }
        public DbSet<KullaniciHareketleri> KullaniciHareketleris { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<KullaniciRolleri> kullaniciRolleris { get; set; }
        public DbSet<Roller> Rollers { get; set; }
        public DbSet<Uyeler> Uyelers { get; set; }

       // BU KISIMA DIKKAT ET IYI ARASTIR.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DuyurullarMap());
            modelBuilder.Configurations.Add(new EmanetKitaplarMap());
            modelBuilder.Configurations.Add(new HakkimizdaMap());
            modelBuilder.Configurations.Add(new IletisimMap());
            modelBuilder.Configurations.Add(new KitapHareketleriMap());
            modelBuilder.Configurations.Add(new KitapKayitHareketleriMap());
            modelBuilder.Configurations.Add(new KitaplarMap());
            modelBuilder.Configurations.Add(new KitapTurleriMap());
            modelBuilder.Configurations.Add(new KullaniciHareketleriMap());
            modelBuilder.Configurations.Add(new KullanicilarMap());
            modelBuilder.Configurations.Add(new KullaniciRolleriMap());
            modelBuilder.Configurations.Add(new RollerMap());
            modelBuilder.Configurations.Add(new UyelerMap());
        }
    }
}
