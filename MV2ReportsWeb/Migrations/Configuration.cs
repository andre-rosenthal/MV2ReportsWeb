namespace MV2ReportsWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MV2ReportsWeb.Models.MV2ReportsWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MV2ReportsWeb.Models.MV2ReportsWebContext";
        }

        protected override void Seed(MV2ReportsWeb.Models.MV2ReportsWebContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
