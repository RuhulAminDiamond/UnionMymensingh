namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxMedicine_RxTest_Template_Model_Created : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RxDiagnosis");
            DropPrimaryKey("dbo.RxDosages");
            DropPrimaryKey("dbo.RxDurations");
            CreateTable(
                "dbo.RxMedicineTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        ProductId = c.Int(nullable: false),
                        DoseId = c.Int(nullable: false),
                        DurationId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhProductInfoes", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.RxDosages", t => t.DoseId, cascadeDelete: true)
                .ForeignKey("dbo.RxDurations", t => t.DurationId, cascadeDelete: true)
                .ForeignKey("dbo.RxMedicineTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.ProductId)
                .Index(t => t.DoseId)
                .Index(t => t.DurationId);
            
            CreateTable(
                "dbo.RxMedicineTemplateMasters",
                c => new
                    {
                        TemplateId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .ForeignKey("dbo.RxDiagnosis", t => t.DiagnosisId, cascadeDelete: true)
                .Index(t => t.CPId)
                .Index(t => t.DiagnosisId);
            
            CreateTable(
                "dbo.RxTestTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxTestTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .ForeignKey("dbo.TestItems", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.RxTestTemplateMasters",
                c => new
                    {
                        TemplateId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        DiagnosisId = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .ForeignKey("dbo.RxDiagnosis", t => t.DiagnosisId, cascadeDelete: true)
                .Index(t => t.CPId)
                .Index(t => t.DiagnosisId);
            
            AddColumn("dbo.User", "ChamberPractitionerId", c => c.Int(nullable: false));
            AddColumn("dbo.RxDiagnosis", "DiagnosisId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RxDosages", "DoseId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RxDurations", "DurationId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RxDiagnosis", "DiagnosisId");
            AddPrimaryKey("dbo.RxDosages", "DoseId");
            AddPrimaryKey("dbo.RxDurations", "DurationId");
            DropColumn("dbo.RxDiagnosis", "Id");
            DropColumn("dbo.RxDosages", "Id");
            DropColumn("dbo.RxDurations", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxDurations", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RxDosages", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.RxDiagnosis", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.RxTestTemplateDetails", "TestId", "dbo.TestItems");
            DropForeignKey("dbo.RxTestTemplateDetails", "TemplateId", "dbo.RxTestTemplateMasters");
            DropForeignKey("dbo.RxTestTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis");
            DropForeignKey("dbo.RxTestTemplateMasters", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "TemplateId", "dbo.RxMedicineTemplateMasters");
            DropForeignKey("dbo.RxMedicineTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis");
            DropForeignKey("dbo.RxMedicineTemplateMasters", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "DurationId", "dbo.RxDurations");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "DoseId", "dbo.RxDosages");
            DropForeignKey("dbo.RxMedicineTemplateDetails", "ProductId", "dbo.PhProductInfoes");
            DropIndex("dbo.RxTestTemplateMasters", new[] { "DiagnosisId" });
            DropIndex("dbo.RxTestTemplateMasters", new[] { "CPId" });
            DropIndex("dbo.RxTestTemplateDetails", new[] { "TestId" });
            DropIndex("dbo.RxTestTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxMedicineTemplateMasters", new[] { "DiagnosisId" });
            DropIndex("dbo.RxMedicineTemplateMasters", new[] { "CPId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "DurationId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "DoseId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "ProductId" });
            DropIndex("dbo.RxMedicineTemplateDetails", new[] { "TemplateId" });
            DropPrimaryKey("dbo.RxDurations");
            DropPrimaryKey("dbo.RxDosages");
            DropPrimaryKey("dbo.RxDiagnosis");
            DropColumn("dbo.RxDurations", "DurationId");
            DropColumn("dbo.RxDosages", "DoseId");
            DropColumn("dbo.RxDiagnosis", "DiagnosisId");
            DropColumn("dbo.User", "ChamberPractitionerId");
            DropTable("dbo.RxTestTemplateMasters");
            DropTable("dbo.RxTestTemplateDetails");
            DropTable("dbo.RxMedicineTemplateMasters");
            DropTable("dbo.RxMedicineTemplateDetails");
            AddPrimaryKey("dbo.RxDurations", "Id");
            AddPrimaryKey("dbo.RxDosages", "Id");
            AddPrimaryKey("dbo.RxDiagnosis", "Id");
        }
    }
}
