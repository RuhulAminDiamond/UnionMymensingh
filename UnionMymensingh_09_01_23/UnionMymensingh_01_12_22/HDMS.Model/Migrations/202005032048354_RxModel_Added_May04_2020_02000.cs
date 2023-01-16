namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_May04_2020_02000 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.TemplateId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: false)
                .Index(t => t.CPId);



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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPPreferredMedicines", t => t.CPPMId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPDrugTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.CPPMId);
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "TemplateId", "dbo.RxCPDrugTemplateMasters");
            DropForeignKey("dbo.RxCPDrugTemplateMasters", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "CPPMId", "dbo.RxCPPreferredMedicines");
            DropIndex("dbo.RxCPDrugTemplateMasters", new[] { "CPId" });
            DropIndex("dbo.RxCPDrugTemplateDetails", new[] { "CPPMId" });
            DropIndex("dbo.RxCPDrugTemplateDetails", new[] { "TemplateId" });
            DropTable("dbo.RxCPDrugTemplateMasters");
            DropTable("dbo.RxCPDrugTemplateDetails");
        }
    }
}
