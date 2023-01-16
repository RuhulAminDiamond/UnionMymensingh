namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatient_Model_Modified_March_07 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxMedicineTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis");
            DropForeignKey("dbo.RxTestTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis");
            DropIndex("dbo.RxMedicineTemplateMasters", new[] { "DiagnosisId" });
            DropIndex("dbo.RxTestTemplateMasters", new[] { "DiagnosisId" });
            RenameColumn(table: "dbo.RxTestTemplateMasters", name: "DiagnosisId", newName: "RxDiagnosis_DiagnosisId");
            AddColumn("dbo.RxMedicineTemplateMasters", "Name", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPSupineTop", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPSupineBottom", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPErectTop", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPErectBottom", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PatientHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PhysicianHistory", c => c.String());
            AddColumn("dbo.RxTestTemplateMasters", "Name", c => c.String());
            AlterColumn("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", c => c.Int());
            CreateIndex("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId");
            AddForeignKey("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", "dbo.RxDiagnosis", "DiagnosisId");
            DropColumn("dbo.RxMedicineTemplateMasters", "DiagnosisId");
            DropColumn("dbo.RxPatientInfoes", "BP");
            DropColumn("dbo.RxPatientInfoes", "PastHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "PastHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BP", c => c.String());
            AddColumn("dbo.RxMedicineTemplateMasters", "DiagnosisId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", "dbo.RxDiagnosis");
            DropIndex("dbo.RxTestTemplateMasters", new[] { "RxDiagnosis_DiagnosisId" });
            AlterColumn("dbo.RxTestTemplateMasters", "RxDiagnosis_DiagnosisId", c => c.Int(nullable: false));
            DropColumn("dbo.RxTestTemplateMasters", "Name");
            DropColumn("dbo.RxPatientInfoes", "PhysicianHistory");
            DropColumn("dbo.RxPatientInfoes", "PatientHistory");
            DropColumn("dbo.RxPatientInfoes", "BPErectBottom");
            DropColumn("dbo.RxPatientInfoes", "BPErectTop");
            DropColumn("dbo.RxPatientInfoes", "BPSupineBottom");
            DropColumn("dbo.RxPatientInfoes", "BPSupineTop");
            DropColumn("dbo.RxMedicineTemplateMasters", "Name");
            RenameColumn(table: "dbo.RxTestTemplateMasters", name: "RxDiagnosis_DiagnosisId", newName: "DiagnosisId");
            CreateIndex("dbo.RxTestTemplateMasters", "DiagnosisId");
            CreateIndex("dbo.RxMedicineTemplateMasters", "DiagnosisId");
            AddForeignKey("dbo.RxTestTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis", "DiagnosisId", cascadeDelete: true);
            AddForeignKey("dbo.RxMedicineTemplateMasters", "DiagnosisId", "dbo.RxDiagnosis", "DiagnosisId", cascadeDelete: true);
        }
    }
}
