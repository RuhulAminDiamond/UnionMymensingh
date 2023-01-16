namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02062018m100 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitions", "RequisitionNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitions", "RequisitionNo");
        }
    }
}
