namespace MVC_kutuphane_otomasyonu_entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_kutuphane_otomasyonu_entities.Model.Context.KutuphaneContext>
    {
        /// <summary>
        /// bu kisima dikkat et.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MVC_kutuphane_otomasyonu_entities.Model.Context.KutuphaneContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
