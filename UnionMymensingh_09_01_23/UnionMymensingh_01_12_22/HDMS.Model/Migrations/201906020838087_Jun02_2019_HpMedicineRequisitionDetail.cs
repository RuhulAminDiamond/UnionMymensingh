namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Jun02_2019_HpMedicineRequisitionDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitionDetails", "DeliveredQty", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitionDetails", "DeliveredQty");
        }
    }
}
