namespace ReforcoEF.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ReforcoEF.Infra.Data.Base.ReforcoEFContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ReforcoEF.Infra.Data.Base.ReforcoEFContexto";
        }

        protected override void Seed(ReforcoEF.Infra.Data.Base.ReforcoEFContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
