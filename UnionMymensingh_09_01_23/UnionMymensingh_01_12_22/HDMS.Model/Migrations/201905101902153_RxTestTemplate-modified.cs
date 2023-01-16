namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxTestTemplatemodified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", "dbo.RxDiagnosis");
            DropIndex("dbo.RxTestTemplateMasters", new[] { "RxDiagnosis_DiagnosisId" });
            DropColumn("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", c => c.Int());
            CreateIndex("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId");
            AddForeignKey("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", "dbo.RxDiagnosis", "DiagnosisId");
        }
    }
}
