namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Modified_May04_2020_0200 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropForeignKey("dbo.RxCPDrugTemplateMasters", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "TemplateId", "dbo.RxCPDrugTemplateMasters");
            DropIndex("dbo.RxCPDrugTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxCPDrugTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.RxCPDrugTemplateMasters", new[] { "CPId" });
           // DropTable("dbo.RxCPDrugTemplateDetails");
           // DropTable("dbo.RxCPDrugTemplateMasters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RxCPDrugTemplateMasters",
                c => new
                    {
                        TemplateId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateId);
            
            CreateTable(
                "dbo.RxCPDrugTemplateDetails",
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RxCPDrugTemplateMasters", "CPId");
            CreateIndex("dbo.RxCPDrugTemplateDetails", "CPPMId");
            CreateIndex("dbo.RxCPDrugTemplateDetails", "TemplateId");
            AddForeignKey("dbo.RxCPDrugTemplateDetails", "TemplateId", "dbo.RxCPDrugTemplateMasters", "TemplateId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPDrugTemplateMasters", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            AddForeignKey("dbo.RxCPDrugTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines", "CPPMId", cascadeDelete: true);
        }
    }
}
