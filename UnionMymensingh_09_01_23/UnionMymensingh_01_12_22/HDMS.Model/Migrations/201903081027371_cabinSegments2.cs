namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cabinSegments2 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HpCabinChargeSegmants");
        }
    }
}
