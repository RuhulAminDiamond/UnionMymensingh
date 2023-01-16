namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinCharges_HpCabinChargeSegmantDetail_Feb04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpCabinCharges", "ServiceHeadId", c => c.Int(nullable: false));
            AddColumn("dbo.HpCabinCharges", "AccomodationTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.HpCabinChargeSegmantDetails", "ServiceHeadId", c => c.Int(nullable: false));
            AddColumn("dbo.HpCabinChargeSegmantDetails", "AccomodationTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpCabinChargeSegmantDetails", "AccomodationTypeId");
            DropColumn("dbo.HpCabinChargeSegmantDetails", "ServiceHeadId");
            DropColumn("dbo.HpCabinCharges", "AccomodationTypeId");
            DropColumn("dbo.HpCabinCharges", "ServiceHeadId");
        }
    }
}
