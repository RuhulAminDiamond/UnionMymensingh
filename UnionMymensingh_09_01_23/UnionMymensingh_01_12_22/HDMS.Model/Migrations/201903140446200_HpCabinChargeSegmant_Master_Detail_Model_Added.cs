namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinChargeSegmant_Master_Detail_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpCabinChargeSegmantDetails",
                c => new
                    {
                        SDId = c.Long(nullable: false, identity: true),
                        SMId = c.Long(nullable: false),
                        BookOrder = c.Long(nullable: false),
                        AdmissionId = c.Long(nullable: false),
                        CabinId = c.Int(nullable: false),
                        CabinNo = c.String(),
                        Rent = c.Int(nullable: false),
                        StayingDate = c.DateTime(nullable: false),
                        StayinDurationInHours = c.Double(nullable: false),
                        IsWithin24Hours = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SDId)
                .ForeignKey("dbo.HpCabinChargeSegmantMasters", t => t.SMId, cascadeDelete: true)
                .Index(t => t.SMId);
            
            CreateTable(
                "dbo.HpCabinChargeSegmantMasters",
                c => new
                    {
                        SMId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        AdmissionDate = c.DateTime(nullable: false),
                        AdmissionTime = c.DateTime(nullable: false),
                        IsAdmissionDayBillApplicable = c.Boolean(nullable: false),
                        IsAdmissionDayAndReleaseDaySame = c.Boolean(nullable: false),
                        IsOccupationMorethanTwoCalendarDate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SMId);
            
            DropTable("dbo.HpCabinChargeSegmants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HpCabinChargeSegmants",
                c => new
                    {
                        BookOrder = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        CabinId = c.Int(nullable: false),
                        CabinNo = c.String(),
                        Rent = c.Int(nullable: false),
                        StayingDate = c.DateTime(nullable: false),
                        StayinDurationInHours = c.Double(nullable: false),
                        IsWithin24Hours = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookOrder);
            
            DropForeignKey("dbo.HpCabinChargeSegmantDetails", "SMId", "dbo.HpCabinChargeSegmantMasters");
            DropIndex("dbo.HpCabinChargeSegmantDetails", new[] { "SMId" });
            DropTable("dbo.HpCabinChargeSegmantMasters");
            DropTable("dbo.HpCabinChargeSegmantDetails");
        }
    }
}
