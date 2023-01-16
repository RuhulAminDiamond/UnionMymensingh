namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nov182018_TestCost_modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "ReportStatus", c => c.String());
            DropColumn("dbo.TestsCost", "DeliveryStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TestsCost", "DeliveryStatus", c => c.String());
            DropColumn("dbo.TestsCost", "ReportStatus");
        }
    }
}
