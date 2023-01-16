namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpMedicineReturnIndentDetail_ModelModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpMedicineReturnIndentDetails", "LotNo", c => c.Long(nullable: false));
            AddColumn("dbo.HpMedicineReturnIndentDetails", "OutLetId", c => c.Int(nullable: false));
            CreateIndex("dbo.HpMedicineReturnIndentDetails", "LotNo");
            CreateIndex("dbo.HpMedicineReturnIndentDetails", "OutLetId");
            AddForeignKey("dbo.HpMedicineReturnIndentDetails", "OutLetId", "dbo.MedicineOutlets", "OutLetId", cascadeDelete: true);
            AddForeignKey("dbo.HpMedicineReturnIndentDetails", "LotNo", "dbo.PhLotInfoes", "LotNo", cascadeDelete: true);
            DropColumn("dbo.HpMedicineReturnIndentDetails", "BatchNo");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "ExpireDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpMedicineReturnIndentDetails", "ExpireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HpMedicineReturnIndentDetails", "BatchNo", c => c.String());
            DropForeignKey("dbo.HpMedicineReturnIndentDetails", "LotNo", "dbo.PhLotInfoes");
            DropForeignKey("dbo.HpMedicineReturnIndentDetails", "OutLetId", "dbo.MedicineOutlets");
            DropIndex("dbo.HpMedicineReturnIndentDetails", new[] { "OutLetId" });
            DropIndex("dbo.HpMedicineReturnIndentDetails", new[] { "LotNo" });
            DropColumn("dbo.HpMedicineReturnIndentDetails", "OutLetId");
            DropColumn("dbo.HpMedicineReturnIndentDetails", "LotNo");
        }
    }
}
