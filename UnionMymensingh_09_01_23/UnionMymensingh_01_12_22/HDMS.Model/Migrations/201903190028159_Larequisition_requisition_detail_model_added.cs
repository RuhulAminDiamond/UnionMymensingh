namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Larequisition_requisition_detail_model_added : DbMigration
    {
        public override void Up()
        {

            CreateTable(
               "dbo.LabRequisitions",
               c => new
               {
                   RequisitionId = c.Long(nullable: false, identity: true),
                   LabId = c.Int(nullable: false),
                   RDate = c.DateTime(nullable: false),
                   RTime = c.String(),
                   OperateBy = c.String(),
                   Status = c.String(),
               })
               .PrimaryKey(t => t.RequisitionId)
               .ForeignKey("dbo.LabInfoes", t => t.LabId, cascadeDelete: true)
               .Index(t => t.LabId);


            CreateTable(
                "dbo.LabRequisitionDetails",
                c => new
                    {
                        RDId = c.Long(nullable: false, identity: true),
                        RequisitionId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RDId)
                .ForeignKey("dbo.LabRequisitions", t => t.RequisitionId, cascadeDelete: true)
                .Index(t => t.RequisitionId);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LabRequisitionDetails", "RequisitionId", "dbo.LabRequisitions");
            DropForeignKey("dbo.LabRequisitions", "LabId", "dbo.LabInfoes");
            DropIndex("dbo.LabRequisitions", new[] { "LabId" });
            DropIndex("dbo.LabRequisitionDetails", new[] { "RequisitionId" });
            DropTable("dbo.LabRequisitions");
            DropTable("dbo.LabRequisitionDetails");
        }
    }
}
