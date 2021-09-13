namespace Disabled.Migrations
{
    using Disabled.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Disabled.DAL.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Disabled.DAL.ShopContext";
        }

        protected override void Seed(Disabled.DAL.ShopContext context)
        {
            ShopInitializer.SeedShopData(context);
            ShopInitializer.InitializeIdentityForEF(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
