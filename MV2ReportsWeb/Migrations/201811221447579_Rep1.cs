namespace MV2ReportsWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rep1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyReports", "Downloaded", c => c.Boolean(nullable: false));
            AddColumn("dbo.MyReports", "Content", c => c.String());
            AddColumn("dbo.MyReports", "EDM", c => c.String());
            AddColumn("dbo.MyReports", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyReports", "EDM");
            DropColumn("dbo.MyReports", "Content");
            DropColumn("dbo.MyReports", "Downloaded");
            DropColumn("dbo.MyReports", "Email");
        }
    }
}
