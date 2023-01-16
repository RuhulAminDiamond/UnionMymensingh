namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxChanges_On_March_03_2020 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RxMedicineTemplateMasters", newName: "RxCPMedicineTemplateMasters");
            RenameTable(name: "dbo.RxTestTemplateMasters", newName: "RxCPTestTemplateMasters");
            DropForeignKey("dbo.RxCPPreferredMedicines", "ProductId", "dbo.PhProductInfoes");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "DoseId", "dbo.RxDosages");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "DurationId", "dbo.RxDurations");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "TemplateId", "dbo.RxMedicineTemplateMasters");
            DropForeignKey("dbo.RxTestTemplateDetails", "TemplateId", "dbo.RxTestTemplateMasters");
            DropForeignKey("dbo.RxTestTemplateDetails", "TestId", "dbo.TestItems");
            DropIndex("dbo.RxCPPreferredMedicines", new[] { "ProductId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "DoseId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "DurationId" });
            DropIndex("dbo.RxTestTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxTestTemplateDetails", new[] { "TestId" });
            CreateTable(
                "dbo.RxCPDiseaseTemplateHistoricalDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DTId = c.Long(nullable: false),
                        HistoryEn = c.String(),
                        HistoryBn = c.String(),
                        PastHistoryEn = c.String(),
                        PastHistoryBn = c.String(),
                        OtherFindingEn = c.String(),
                        OtherFindingBn = c.String(),
                        TreatmentPlanEn = c.String(),
                        TreatmentPlanBn = c.String(),
                        DrugHistory = c.String(),
                        Diagnosis = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPDiseaseTemplates", t => t.DTId, cascadeDelete: true)
                .Index(t => t.DTId);
            
            CreateTable(
                "dbo.RxCPDiseaseTemplates",
                c => new
                    {
                        DTId = c.Long(nullable: false, identity: true),
                        CpId = c.Int(nullable: false),
                        DiseaseName = c.String(),
                        TerminalMacAddress = c.String(),
                    })
                .PrimaryKey(t => t.DTId);
            
            CreateTable(
                "dbo.RxCPDiseaseTemplateTestDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DTId = c.Long(nullable: false),
                        CPPTId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPDiseaseTemplates", t => t.DTId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPPreferredTests", t => t.CPPTId, cascadeDelete: true)
                .Index(t => t.DTId)
                .Index(t => t.CPPTId);
            
            CreateTable(
                "dbo.RxCPPreferredTests",
                c => new
                    {
                        CPPTId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        TestId = c.Int(nullable: false),
                        TestName = c.String(),
                    })
                .PrimaryKey(t => t.CPPTId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCPDiseaseTemplateTreatmentDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DTId = c.Long(nullable: false),
                        CPPMId = c.Long(nullable: false),
                        dosage = c.String(),
                        duration = c.String(),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPDiseaseTemplates", t => t.DTId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPPreferredMedicines", t => t.CPPMId, cascadeDelete: true)
                .Index(t => t.DTId)
                .Index(t => t.CPPMId);
            
            CreateTable(
                "dbo.RxCPMedicineTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        CPPMId = c.Long(nullable: false),
                        DoseShortEn = c.String(),
                        DoseShortBn = c.String(),
                        DoseLongEn = c.String(),
                        DoseLongBn = c.String(),
                        BeforeAfterEn = c.String(),
                        BeforeAfterBn = c.String(),
                        Duration = c.String(),
                        DurationUnit = c.String(),
                        Qty = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
               // .ForeignKey("dbo.RxCPPreferredMedicines", t => t.CPPMId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPMedicineTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.CPPMId);
            
            CreateTable(
                "dbo.RxCPTestTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPTestTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .ForeignKey("dbo.TestItems", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.TestId);
            
            AddColumn("dbo.RxCPPreferredMedicines", "BrandName", c => c.String());
            AddColumn("dbo.RxCPPreferredMedicines", "ManufacturerId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPPreferredMedicines", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPPreferredMedicines", "GenericId", c => c.Int(nullable: false));
            AddColumn("dbo.RxDrugs", "CPPMId", c => c.Long(nullable: false));
            AddColumn("dbo.RxInitialDatas", "TerminalMacAddress", c => c.String());
            AddColumn("dbo.RxPatientMasterDatas", "TerminalMacAddress", c => c.String());
            CreateIndex("dbo.RxDrugs", "CPPMId");
            AddForeignKey("dbo.RxDrugs", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
            DropColumn("dbo.RxDrugs", "ProductId");
            DropTable("dbo.RxMedicineTemplateDetails");
            DropTable("dbo.RxTestTemplateDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RxTestTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxMedicineTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        CPPMId = c.Long(nullable: false),
                        DoseId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RxDrugs", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RxDrugs", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPTestTemplateDetails", "TestId", "dbo.TestItems");
            DropForeignKey("dbo.RxCPTestTemplateDetails", "TemplateId", "dbo.RxCPTestTemplateMasters");
            DropForeignKey("dbo.RxCPMedicineTemplateDetails", "TemplateId", "dbo.RxCPMedicineTemplateMasters");
            DropForeignKey("dbo.RxCPMedicineTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPDiseaseTemplateTreatmentDatas", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPDiseaseTemplateTreatmentDatas", "DTId", "dbo.RxCPDiseaseTemplates");
            DropForeignKey("dbo.RxCPDiseaseTemplateTestDatas", "CPPTId", "dbo.RxCPPreferredTests");
            DropForeignKey("dbo.RxCPPreferredTests", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPDiseaseTemplateTestDatas", "DTId", "dbo.RxCPDiseaseTemplates");
            DropForeignKey("dbo.RxCPDiseaseTemplateHistoricalDatas", "DTId", "dbo.RxCPDiseaseTemplates");
            DropIndex("dbo.RxDrugs", new[] { "CPPMId" });
            DropIndex("dbo.RxCPTestTemplateDetails", new[] { "TestId" });
            DropIndex("dbo.RxCPTestTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxCPMedicineTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.RxCPMedicineTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxCPDiseaseTemplateTreatmentDatas", new[] { "CPPMId" });
            DropIndex("dbo.RxCPDiseaseTemplateTreatmentDatas", new[] { "DTId" });
            DropIndex("dbo.RxCPPreferredTests", new[] { "CPId" });
            DropIndex("dbo.RxCPDiseaseTemplateTestDatas", new[] { "CPPTId" });
            DropIndex("dbo.RxCPDiseaseTemplateTestDatas", new[] { "DTId" });
            DropIndex("dbo.RxCPDiseaseTemplateHistoricalDatas", new[] { "DTId" });
            DropColumn("dbo.RxPatientMasterDatas", "TerminalMacAddress");
            DropColumn("dbo.RxInitialDatas", "TerminalMacAddress");
            DropColumn("dbo.RxDrugs", "CPPMId");
            DropColumn("dbo.RxCPPreferredMedicines", "GenericId");
            DropColumn("dbo.RxCPPreferredMedicines", "GroupId");
            DropColumn("dbo.RxCPPreferredMedicines", "ManufacturerId");
            DropColumn("dbo.RxCPPreferredMedicines", "BrandName");
            DropTable("dbo.RxCPTestTemplateDetails");
            DropTable("dbo.RxCPMedicineTemplateDetails");
            DropTable("dbo.RxCPDiseaseTemplateTreatmentDatas");
            DropTable("dbo.RxCPPreferredTests");
            DropTable("dbo.RxCPDiseaseTemplateTestDatas");
            DropTable("dbo.RxCPDiseaseTemplates");
            DropTable("dbo.RxCPDiseaseTemplateHistoricalDatas");
            CreateIndex("dbo.RxTestTemplateDetails", "TestId");
            CreateIndex("dbo.RxTestTemplateDetails", "TemplateId");
            CreateIndex("dbo.RxMedicineTemplateDetails", "DurationId");
            CreateIndex("dbo.RxMedicineTemplateDetails", "DoseId");
            CreateIndex("dbo.RxMedicineTemplateDetails", "CPPMId");
            CreateIndex("dbo.RxMedicineTemplateDetails", "TemplateId");
            CreateIndex("dbo.RxCPPreferredMedicines", "ProductId");
            AddForeignKey("dbo.RxTestTemplateDetails", "TestId", "dbo.TestItems", "TestId", cascadeDelete: true);
            AddForeignKey("dbo.RxTestTemplateDetails", "TemplateId", "dbo.RxTestTemplateMasters", "TemplateId", cascadeDelete: true);
            AddForeignKey("dbo.RxMedicineTemplateDetails", "TemplateId", "dbo.RxMedicineTemplateMasters", "TemplateId", cascadeDelete: true);
            AddForeignKey("dbo.RxMedicineTemplateDetails", "DurationId", "dbo.RxDurations", "DurationId", cascadeDelete: true);
            AddForeignKey("dbo.RxMedicineTemplateDetails", "DoseId", "dbo.RxDosages", "DoseId", cascadeDelete: true);
            AddForeignKey("dbo.RxMedicineTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPPreferredMedicines", "ProductId", "dbo.PhProductInfoes", "ProductId", cascadeDelete: true);
            RenameTable(name: "dbo.RxCPTestTemplateMasters", newName: "RxTestTemplateMasters");
            RenameTable(name: "dbo.RxCPMedicineTemplateMasters", newName: "RxMedicineTemplateMasters");
        }
    }
}
