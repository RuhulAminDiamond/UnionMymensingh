namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReportDeliveryTimingMaster_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportDeliveryTimingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RDTMId = c.Int(nullable: false),
                        StartTime = c.String(),
                        DeliveryTime = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportDeliveryTimingMasters", t => t.RDTMId, cascadeDelete: true)
                .Index(t => t.RDTMId);
            
            CreateTable(
                "dbo.ReportDeliveryTimingMasters",
                c => new
                    {
                        RDTMId = c.Int(nullable: false, identity: true),
                        TotalDeliverySlot = c.Int(nullable: false),
                        IsActiveNow = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RDTMId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportDeliveryTimingDetails", "RDTMId", "dbo.ReportDeliveryTimingMasters");
            DropIndex("dbo.ReportDeliveryTimingDetails", new[] { "RDTMId" });
            DropTable("dbo.ReportDeliveryTimingMasters");
            DropTable("dbo.ReportDeliveryTimingDetails");
        }
    }
}
