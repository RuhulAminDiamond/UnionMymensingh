namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12062018m2001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpMedicineReturnIndentDetails",
                c => new
                    {
                        ReturnIndentDetailId = c.Long(nullable: false, identity: true),
                        ReturnIndentId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnIndentDetailId)
                .ForeignKey("dbo.HpMedicineReturnInednts", t => t.ReturnIndentId, cascadeDelete: true)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ReturnIndentId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.HpMedicineReturnInednts",
                c => new
                    {
                        ReturnIndentId = c.Long(nullable: false, identity: true),
                        ReturnIndentNo = c.Long(nullable: false),
                        ReqDate = c.DateTime(nullable: false),
                        AdmissionId = c.Long(nullable: false),
                        OutletId = c.Int(nullable: false),
                        ReturnType = c.String(),
                        ReturnIndentBy = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ReturnIndentId);
            
            AddColumn("dbo.PhReceives", "ReceiveType", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpMedicineReturnIndentDetails", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.HpMedicineReturnIndentDetails", "ReturnIndentId", "dbo.HpMedicineReturnInednts");
            DropIndex("dbo.HpMedicineReturnIndentDetails", new[] { "ProductId" });
            DropIndex("dbo.HpMedicineReturnIndentDetails", new[] { "ReturnIndentId" });
            DropColumn("dbo.PhReceives", "ReceiveType");
            DropTable("dbo.HpMedicineReturnInednts");
            DropTable("dbo.HpMedicineReturnIndentDetails");
        }
    }
}
