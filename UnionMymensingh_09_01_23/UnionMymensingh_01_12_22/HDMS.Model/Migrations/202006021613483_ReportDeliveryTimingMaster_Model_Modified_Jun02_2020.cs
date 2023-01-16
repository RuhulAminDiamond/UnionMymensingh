namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportDeliveryTimingMaster_Model_Modified_Jun02_2020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReportDeliveryTimingMasters", "OrgCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportDeliveryTimingMasters", "OrgCode");
        }
    }
}
