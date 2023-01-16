namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Modified_Jun07_2020_09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxCPDiseaseTemplateTestDatas", "CPPTId", "dbo.RxCPPreferredTests");
            DropForeignKey("dbo.RxCPDiseaseTemplateTreatmentDatas", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPTestTemplateDetails", "CPPTId", "dbo.RxCPPreferredTests");
            DropIndex("dbo.RxCPDiseaseTemplateTestDatas", new[] { "CPPTId" });
            DropIndex("dbo.RxCPDiseaseTemplateTreatmentDatas", new[] { "CPPMId" });
            DropIndex("dbo.RxCPDrugTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.RxCPTestTemplateDetails", new[] { "CPPTId" });
            AddColumn("dbo.RxCPDiseaseTemplateAdviceDatas", "Advice", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateTestDatas", "TestId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPDiseaseTemplateTreatmentDatas", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPDrugTemplateDetails", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.RxCPTestTemplateDetails", "TestId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxCPTestTemplateDetails", "TestId");
            DropColumn("dbo.RxCPDrugTemplateDetails", "ProductId");
            DropColumn("dbo.RxCPDiseaseTemplateTreatmentDatas", "ProductId");
            DropColumn("dbo.RxCPDiseaseTemplateTestDatas", "TestId");
            DropColumn("dbo.RxCPDiseaseTemplateAdviceDatas", "Advice");
            CreateIndex("dbo.RxCPTestTemplateDetails", "CPPTId");
            CreateIndex("dbo.RxCPDrugTemplateDetails", "CPPMId");
            CreateIndex("dbo.RxCPDiseaseTemplateTreatmentDatas", "CPPMId");
            CreateIndex("dbo.RxCPDiseaseTemplateTestDatas", "CPPTId");
            AddForeignKey("dbo.RxCPTestTemplateDetails", "CPPTId", "dbo.RxCPPreferredTests", "CPPTId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPDrugTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPDiseaseTemplateTreatmentDatas", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPDiseaseTemplateTestDatas", "CPPTId", "dbo.RxCPPreferredTests", "CPPTId", cascadeDelete: true);
        }
    }
}
