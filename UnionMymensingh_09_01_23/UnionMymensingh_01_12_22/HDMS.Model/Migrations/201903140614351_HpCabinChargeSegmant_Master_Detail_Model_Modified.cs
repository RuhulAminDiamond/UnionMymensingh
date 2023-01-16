namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinChargeSegmant_Master_Detail_Model_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpCabinChargeSegmantDetails", "IsAdmissionDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.HpCabinChargeSegmantDetails", "OccupationStatus", c => c.Boolean(nullable: false));
            AlterColumn("dbo.HpCabinChargeSegmantMasters", "AdmissionTime", c => c.String());
            DropColumn("dbo.HpCabinChargeSegmantDetails", "StayinDurationInHours");
            DropColumn("dbo.HpCabinChargeSegmantDetails", "IsWithin24Hours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpCabinChargeSegmantDetails", "IsWithin24Hours", c => c.Boolean(nullable: false));
            AddColumn("dbo.HpCabinChargeSegmantDetails", "StayinDurationInHours", c => c.Double(nullable: false));
            AlterColumn("dbo.HpCabinChargeSegmantMasters", "AdmissionTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.HpCabinChargeSegmantDetails", "OccupationStatus");
            DropColumn("dbo.HpCabinChargeSegmantDetails", "IsAdmissionDay");
        }
    }
}
