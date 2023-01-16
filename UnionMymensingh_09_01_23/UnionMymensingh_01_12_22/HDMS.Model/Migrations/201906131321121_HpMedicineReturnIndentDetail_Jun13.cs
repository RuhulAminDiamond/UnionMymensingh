namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpMedicineReturnIndentDetail_Jun13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineRequisitionDetails", "ReplaceRemarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HpMedicineRequisitionDetails", "ReplaceRemarks");
        }
    }
}
