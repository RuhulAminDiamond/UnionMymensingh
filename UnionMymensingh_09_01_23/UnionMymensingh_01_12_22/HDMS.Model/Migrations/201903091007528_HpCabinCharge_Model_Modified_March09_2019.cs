namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinCharge_Model_Modified_March09_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpCabinCharges", "BookingOrder", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpCabinCharges", "BookingOrder");
        }
    }
}
