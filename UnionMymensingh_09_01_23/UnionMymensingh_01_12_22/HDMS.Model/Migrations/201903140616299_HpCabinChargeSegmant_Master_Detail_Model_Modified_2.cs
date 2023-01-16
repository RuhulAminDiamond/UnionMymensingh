namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinChargeSegmant_Master_Detail_Model_Modified_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HpCabinChargeSegmantDetails", "OccupationStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HpCabinChargeSegmantDetails", "OccupationStatus", c => c.Boolean(nullable: false));
        }
    }
}
