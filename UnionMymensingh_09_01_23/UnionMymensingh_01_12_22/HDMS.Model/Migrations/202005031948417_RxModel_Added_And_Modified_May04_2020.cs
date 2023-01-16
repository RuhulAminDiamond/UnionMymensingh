namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModel_Added_And_Modified_May04_2020 : DbMigration
    {
        public override void Up()
        {
           // RenameTable(name: "dbo.RxCPMedicineTemplateDetails", newName: "RxCPDrugTemplateDetails");
            RenameTable(name: "dbo.RxCPMedicineTemplateMasters", newName: "RxCpAdviceTemplateMasters");
            DropForeignKey("dbo.RxCPMedicineTemplateDetails", "TemplateId", "dbo.RxCPMedicineTemplateMasters");
            CreateTable(
                "dbo.RxCpAdditionalInfoTemplates",
                c => new
                    {
                        RxAITId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Name = c.String(),
                        AdditionalInfo = c.String(),
                    })
                .PrimaryKey(t => t.RxAITId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCpAdviceTemplateDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TemplateId = c.Long(nullable: false),
                        RxCpAdvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPAdvices", t => t.RxCpAdvId, cascadeDelete: true)
                .ForeignKey("dbo.RxCpAdviceTemplateMasters", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId)
                .Index(t => t.RxCpAdvId);
            
            CreateTable(
                "dbo.RxCpDrugHistoryTemplates",
                c => new
                    {
                        RxDhTId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Name = c.String(),
                        DrugHistory = c.String(),
                    })
                .PrimaryKey(t => t.RxDhTId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCpHistoryTemplates",
                c => new
                    {
                        RxHTId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Name = c.String(),
                        History = c.String(),
                    })
                .PrimaryKey(t => t.RxHTId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
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
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCpOtherFindingTemplates",
                c => new
                    {
                        RxOFTId = c.Long(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Name = c.String(),
                        OtherFinding = c.String(),
                    })
                .PrimaryKey(t => t.RxOFTId)
                .ForeignKey("dbo.ChamberPractitioners", t => t.CPId, cascadeDelete: true)
                .Index(t => t.CPId);
            
            CreateTable(
                "dbo.RxCpSupportUserAccessOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupportUserId = c.Int(nullable: false),
                        AccessOption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "CpId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Comments", c => c.String());
            AddColumn("dbo.RxCPAdvices", "ShortKey", c => c.String());
            AddColumn("dbo.RxCpDosages", "ShortKey", c => c.String());
           // AddForeignKey("dbo.RxCPDrugTemplateDetails", "TemplateId", "dbo.RxCPDrugTemplateMasters", "TemplateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxCpOtherFindingTemplates", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCPDrugTemplateDetails", "TemplateId", "dbo.RxCPDrugTemplateMasters");
            DropForeignKey("dbo.RxCpHistoryTemplates", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCpDrugHistoryTemplates", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxCpAdviceTemplateDetails", "TemplateId", "dbo.RxCpAdviceTemplateMasters");
            DropForeignKey("dbo.RxCpAdviceTemplateDetails", "RxCpAdvId", "dbo.RxCPAdvices");
            DropForeignKey("dbo.RxCpAdditionalInfoTemplates", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxCpOtherFindingTemplates", new[] { "CPId" });
            DropIndex("dbo.RxCPDrugTemplateMasters", new[] { "CPId" });
            DropIndex("dbo.RxCpHistoryTemplates", new[] { "CPId" });
            DropIndex("dbo.RxCpDrugHistoryTemplates", new[] { "CPId" });
            DropIndex("dbo.RxCpAdviceTemplateDetails", new[] { "RxCpAdvId" });
            DropIndex("dbo.RxCpAdviceTemplateDetails", new[] { "TemplateId" });
            DropIndex("dbo.RxCpAdditionalInfoTemplates", new[] { "CPId" });
            DropColumn("dbo.RxCpDosages", "ShortKey");
            DropColumn("dbo.RxCPAdvices", "ShortKey");
            DropColumn("dbo.User", "Comments");
            DropColumn("dbo.User", "CpId");
            DropTable("dbo.RxCpSupportUserAccessOptions");
            DropTable("dbo.RxCpOtherFindingTemplates");
            DropTable("dbo.RxCPDrugTemplateMasters");
            DropTable("dbo.RxCpHistoryTemplates");
            DropTable("dbo.RxCpDrugHistoryTemplates");
            DropTable("dbo.RxCpAdviceTemplateDetails");
            DropTable("dbo.RxCpAdditionalInfoTemplates");
            //AddForeignKey("dbo.RxCPMedicineTemplateDetails", "TemplateId", "dbo.RxCPMedicineTemplateMasters", "TemplateId", cascadeDelete: true);
            RenameTable(name: "dbo.RxCpAdviceTemplateMasters", newName: "RxCPMedicineTemplateMasters");
            RenameTable(name: "dbo.RxCPDrugTemplateDetails", newName: "RxCPMedicineTemplateDetails");
        }
    }
}
