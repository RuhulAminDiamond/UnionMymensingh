namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestsCost_Model_Modified_Aug29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestsCost", "ReportDeliveredBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestsCost", "ReportDeliveredBy");
        }
    }
}
