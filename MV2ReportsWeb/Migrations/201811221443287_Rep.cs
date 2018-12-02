namespace MV2ReportsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyReports", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyReports", "Email");
        }
    }
}
