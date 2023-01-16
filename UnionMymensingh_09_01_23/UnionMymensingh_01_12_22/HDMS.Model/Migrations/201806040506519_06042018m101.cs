namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06042018m101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitions", "OutletId", c => c.Int(nullable: false));
            AddColumn("dbo.HpMedicineRequisitions", "RequisitionType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitions", "RequisitionType");
            DropColumn("dbo.HpMedicineRequisitions", "OutletId");
        }
    }
}
