namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxDoseEMRInterpretation_Model_Added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", "dbo.RxCPAdvices");
            DropIndex("dbo.RxCpAdviceTemplateDetails", new[] { "RxCpAdvId" });
            CreateTable(
                "dbo.RxDoseEMRInterpretations",
                c => new
                    {
                        EmrIId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        InPCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmrIId);
            
            AddColumn("dbo.RxCpAdviceTemplateDetails", "Advice", c => c.String());
            AddColumn("dbo.RxCpAdviceTemplateMasters", "IsDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxCPDrugTemplateDetails", "Dosage", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateMasters", "IsDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.RxCPTestTemplateMasters", "IsDefault", c => c.Boolean(nullable: false));
            DropColumn("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId");
            DropColumn("dbo.RxCPDrugTemplateDetails", "DoseShortEn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "DoseShortBn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "DoseLongEn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "DoseLongBn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "BeforeAfterEn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "BeforeAfterBn");
            DropColumn("dbo.RxCPDrugTemplateDetails", "DurationUnit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxCPDrugTemplateDetails", "DurationUnit", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "BeforeAfterBn", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "BeforeAfterEn", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "DoseLongBn", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "DoseLongEn", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "DoseShortBn", c => c.String());
            AddColumn("dbo.RxCPDrugTemplateDetails", "DoseShortEn", c => c.String());
            AddColumn("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", c => c.Int(nullable: false));
            DropColumn("dbo.RxCPTestTemplateMasters", "IsDefault");
            DropColumn("dbo.RxCPDrugTemplateMasters", "IsDefault");
            DropColumn("dbo.RxCPDrugTemplateDetails", "Dosage");
            DropColumn("dbo.RxCpAdviceTemplateMasters", "IsDefault");
            DropColumn("dbo.RxCpAdviceTemplateDetails", "Advice");
            DropTable("dbo.RxDoseEMRInterpretations");
            CreateIndex("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId");
            AddForeignKey("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", "dbo.RxCPAdvices", "RxCpAdvId", cascadeDelete: true);
        }
    }
}
