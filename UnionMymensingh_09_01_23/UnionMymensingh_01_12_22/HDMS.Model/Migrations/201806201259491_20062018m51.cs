namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20062018m51 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HpMedicineRequisitions", "RequisitionNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpMedicineRequisitions", "RequisitionNo", c => c.Long(nullable: false));
        }
    }
}
