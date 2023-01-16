namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06022018m29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpMedicineRequisitionDetails",
                c => new
                    {
                        ReqDetailId = c.Long(nullable: false, identity: true),
                        RequisitionId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReqDetailId)
                .ForeignKey("dbo.HpMedicineRequisitions", t => t.RequisitionId, cascadeDelete: true)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.RequisitionId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.HpMedicineRequisitions",
                c => new
                    {
                        RequisitionId = c.Long(nullable: false, identity: true),
                        ReqDate = c.DateTime(nullable: false),
                        AdmissionId = c.Long(nullable: false),
                        RequisitionBy = c.String(),
                    })
                .PrimaryKey(t => t.RequisitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpMedicineRequisitionDetails", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.HpMedicineRequisitionDetails", "RequisitionId", "dbo.HpMedicineRequisitions");
            DropIndex("dbo.HpMedicineRequisitionDetails", new[] { "ProductId" });
            DropIndex("dbo.HpMedicineRequisitionDetails", new[] { "RequisitionId" });
            DropTable("dbo.HpMedicineRequisitions");
            DropTable("dbo.HpMedicineRequisitionDetails");
        }
    }
}
