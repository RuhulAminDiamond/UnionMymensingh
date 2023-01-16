namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientInfo_Modified_Apr14_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "ChiefComplains", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Presentillness", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Pastillness", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "FamilyHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PersonalHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "SocioEconomicHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PsychiatricHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "DrugAndTreatmentHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "AllergyHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "ImmunizationHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "MeanstrualAndObstetricHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "OtherHistory", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "ChiefComplain");
            DropColumn("dbo.RxPatientInfoes", "PatientHistory");
            DropColumn("dbo.RxPatientInfoes", "PhysicianHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "PhysicianHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PatientHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "ChiefComplain", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "OtherHistory");
            DropColumn("dbo.RxPatientInfoes", "MeanstrualAndObstetricHistory");
            DropColumn("dbo.RxPatientInfoes", "ImmunizationHistory");
            DropColumn("dbo.RxPatientInfoes", "AllergyHistory");
            DropColumn("dbo.RxPatientInfoes", "DrugAndTreatmentHistory");
            DropColumn("dbo.RxPatientInfoes", "PsychiatricHistory");
            DropColumn("dbo.RxPatientInfoes", "SocioEconomicHistory");
            DropColumn("dbo.RxPatientInfoes", "PersonalHistory");
            DropColumn("dbo.RxPatientInfoes", "FamilyHistory");
            DropColumn("dbo.RxPatientInfoes", "Pastillness");
            DropColumn("dbo.RxPatientInfoes", "Presentillness");
            DropColumn("dbo.RxPatientInfoes", "ChiefComplains");
        }
    }
}
