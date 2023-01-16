namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestItem_Modified_July25_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TestItems", "DayNeededForReportDelivery", c => c.Int(nullable: false));
            AddColumn("dbo.TestItems", "EscapeDayNeededForReportDeliveryDayCount", c => c.Int(nullable: false));
            AddColumn("dbo.TestItems", "DeliveryTimeOnReportDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TestItems", "DeliveryTimeOnReportDay");
            DropColumn("dbo.TestItems", "EscapeDayNeededForReportDeliveryDayCount");
            DropColumn("dbo.TestItems", "DayNeededForReportDelivery");
        }
    }
}
