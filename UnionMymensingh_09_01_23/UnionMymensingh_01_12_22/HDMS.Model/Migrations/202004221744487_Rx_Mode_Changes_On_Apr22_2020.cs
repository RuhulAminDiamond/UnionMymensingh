namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rx_Mode_Changes_On_Apr22_2020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxCPDiseaseTemplateAdviceDatas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DTId = c.Long(nullable: false),
                        RxCpAdvId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RxCPAdvices", t => t.RxCpAdvId, cascadeDelete: true)
                .ForeignKey("dbo.RxCPDiseaseTemplates", t => t.DTId, cascadeDelete: true)
                .Index(t => t.DTId)
                .Index(t => t.RxCpAdvId);
            
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "CC", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PresentHistory", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistory", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPaln", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindings", c => c.String());
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "HistoryEn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "HistoryBn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistoryEn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistoryBn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindingEn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindingBn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPlanEn");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPlanBn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPlanBn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPlanEn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindingBn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindingEn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistoryBn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistoryEn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "HistoryBn", c => c.String());
            AddColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "HistoryEn", c => c.String());
            DropForeignKey("dbo.RxCPDiseaseTemplateAdviceDatas", "DTId", "dbo.RxCPDiseaseTemplates");
            DropForeignKey("dbo.RxCPDiseaseTemplateAdviceDatas", "RxCpAdvId", "dbo.RxCPAdvices");
            DropIndex("dbo.RxCPDiseaseTemplateAdviceDatas", new[] { "RxCpAdvId" });
            DropIndex("dbo.RxCPDiseaseTemplateAdviceDatas", new[] { "DTId" });
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "OtherFindings");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "TreatmentPaln");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PastHistory");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "PresentHistory");
            DropColumn("dbo.RxCPDiseaseTemplateHistoricalDatas", "CC");
            DropTable("dbo.RxCPDiseaseTemplateAdviceDatas");
        }
    }
}
