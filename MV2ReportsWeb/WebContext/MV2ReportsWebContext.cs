using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MV2ReportsWeb.Models
{
    public class MV2ReportsWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MV2ReportsWebContext() : base("name=MV2ReportsWebContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MV2ReportsWebContext, Migrations.Configuration>());
        }

        public System.Data.Entity.DbSet<MV2ReportsWeb.Models.MyReports> MyReports { get; set; }
        public System.Data.Entity.DbSet<MV2ReportsWeb.Models.Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<MV2ReportsWeb.Models.Scheduler> Schedulers { get; set; }
    }
}
