namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathologyReport_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PathologyReports", "ReportType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PathologyReports", "ReportType", c => c.String());
        }
    }
}
