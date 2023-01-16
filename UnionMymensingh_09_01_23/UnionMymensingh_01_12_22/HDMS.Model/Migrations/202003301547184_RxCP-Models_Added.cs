namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxCPModels_Added : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CPPreferredMedicines", newName: "RxCPPreferredMedicines");
            RenameTable(name: "dbo.RxSavedAdvices", newName: "RxCPAdvices");
            DropForeignKey("dbo.RxGeneralPhysicalExamSubItems", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxGeneralPhysicalExamSubItems", "RxGPExamId", "dbo.RxGeneralPhysicalExamItems");
            DropForeignKey("dbo.RxPatientHistorySubItems", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxPatientHistorySubItems", "RxHItemId", "dbo.RxPatientHistoryItems");
            DropIndex("dbo.RxGeneralPhysicalExamSubItems", new[] { "RxGPExamId" });
            DropIndex("dbo.RxGeneralPhysicalExamSubItems", new[] { "CPId" });
            DropIndex("dbo.RxPatientHistorySubItems", new[] { "RxHItemId" });
            DropIndex("dbo.RxPatientHistorySubItems", new[] { "CPId" });
            CreateTable(
                "dbo.RxCPDrugHistories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        DrugHistory = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCPHistories",
                c => new
                    {
                        RxHId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        HistoryEn = c.String(),
                        HistoryBn = c.String(),
                    })
                .PrimaryKey(t => t.RxHId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCPOtherFindings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        OtherFindingEn = c.String(),
                        OtherFindingBn = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCPPastHistories",
                c => new
                    {
                        RxPHId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        HistoryEn = c.String(),
                        HistoryBn = c.String(),
                    })
                .PrimaryKey(t => t.RxPHId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCPTreatmentPlans",
                c => new
                    {
                        RxTPId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        TreatmentPlanEn = c.String(),
                        TreatmentPlanBn = c.String(),
                    })
                .PrimaryKey(t => t.RxTPId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateIndex("dbo.RxCPAdvices", "CPId");
            AddForeignKey("dbo.RxCPAdvices", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            DropTable("dbo.RxGeneralPhysicalExamItems");
            DropTable("dbo.RxGeneralPhysicalExamSubItems");
            DropTable("dbo.RxPatientHistoryItems");
            DropTable("dbo.RxPatientHistorySubItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RxPatientHistorySubItems",
                c => new
                    {
                        RxHSubItemId = c.Int(nullable: false, identity: true),
                        RxHItemId = c.Int(nullable: false),
                        CPId = c.Int(nullable: false),
                        SubItemName = c.String(),
                    })
                .PrimaryKey(t => t.RxHSubItemId);
            
            CreateTable(
                "dbo.RxPatientHistoryItems",
                c => new
                    {
                        RxHItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCode = c.String(),
                    })
                .PrimaryKey(t => t.RxHItemId);
            
            CreateTable(
                "dbo.RxGeneralPhysicalExamSubItems",
                c => new
                    {
                        RxGPExamSubItemId = c.Int(nullable: false, identity: true),
                        RxGPExamId = c.Int(nullable: false),
                        CPId = c.Int(nullable: false),
                        SubItemName = c.String(),
                    })
                .PrimaryKey(t => t.RxGPExamSubItemId);
            
            CreateTable(
                "dbo.RxGeneralPhysicalExamItems",
                c => new
                    {
                        RxGPExamId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemCode = c.String(),
                    })
                .PrimaryKey(t => t.RxGPExamId);
            
            DropForeignKey("dbo.RxCPTreatmentPlans", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPPastHistories", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPOtherFindings", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPHistories", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPDrugHistories", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPAdvices", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxCPTreatmentPlans", new[] { "CPId" });
            DropIndex("dbo.RxCPPastHistories", new[] { "CPId" });
            DropIndex("dbo.RxCPOtherFindings", new[] { "CPId" });
            DropIndex("dbo.RxCPHistories", new[] { "CPId" });
            DropIndex("dbo.RxCPDrugHistories", new[] { "CPId" });
            DropIndex("dbo.RxCPAdvices", new[] { "CPId" });
            DropTable("dbo.RxCPTreatmentPlans");
            DropTable("dbo.RxCPPastHistories");
            DropTable("dbo.RxCPOtherFindings");
            DropTable("dbo.RxCPHistories");
            DropTable("dbo.RxCPDrugHistories");
            CreateIndex("dbo.RxPatientHistorySubItems", "CPId");
            CreateIndex("dbo.RxPatientHistorySubItems", "RxHItemId");
            CreateIndex("dbo.RxGeneralPhysicalExamSubItems", "CPId");
            CreateIndex("dbo.RxGeneralPhysicalExamSubItems", "RxGPExamId");
            AddForeignKey("dbo.RxPatientHistorySubItems", "RxHItemId", "dbo.RxPatientHistoryItems", "RxHItemId", cascadeDelete: true);
            AddForeignKey("dbo.RxPatientHistorySubItems", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            AddForeignKey("dbo.RxGeneralPhysicalExamSubItems", "RxGPExamId", "dbo.RxGeneralPhysicalExamItems", "RxGPExamId", cascadeDelete: true);
            AddForeignKey("dbo.RxGeneralPhysicalExamSubItems", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            RenameTable(name: "dbo.RxCPAdvices", newName: "RxSavedAdvices");
            RenameTable(name: "dbo.RxCPPreferredMedicines", newName: "CPPreferredMedicines");
        }
    }
}
