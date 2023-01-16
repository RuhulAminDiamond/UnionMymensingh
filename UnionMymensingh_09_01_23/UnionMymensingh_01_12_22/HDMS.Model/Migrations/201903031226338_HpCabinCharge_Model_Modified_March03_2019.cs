namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpCabinCharge_Model_Modified_March03_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpCabinCharges", "BillJustification", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpCabinCharges", "BillJustification");
        }
    }
}
