namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_RxPatientInfo_Modidfied_May15 : DbMigration
    {
        public override void Up()
        {
          //  DropPrimaryKey("dbo.RxPatientInfoes");
            AddColumn("dbo.RxPatientInfoes", "RxId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.RxPatientInfoes", "CPId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.RxPatientInfoes", "RxId");
            CreateIndex("dbo.RxPatientInfoes", "CPId");
            AddForeignKey("dbo.RxPatientInfoes", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
            DropColumn("dbo.RxPatientInfoes", "Id");
            DropColumn("dbo.RxPatientInfoes", "PractitionerId");
            DropColumn("dbo.RxPatientInfoes", "Pulse");
            DropColumn("dbo.RxPatientInfoes", "BPSupineTop");
            DropColumn("dbo.RxPatientInfoes", "BPSupineBottom");
            DropColumn("dbo.RxPatientInfoes", "BPErectTop");
            DropColumn("dbo.RxPatientInfoes", "BPErectBottom");
            DropColumn("dbo.RxPatientInfoes", "Weight");
            DropColumn("dbo.RxPatientInfoes", "ChiefComplains");
            DropColumn("dbo.RxPatientInfoes", "CCDuration");
            DropColumn("dbo.RxPatientInfoes", "Presentillness");
            DropColumn("dbo.RxPatientInfoes", "Pastillness");
            DropColumn("dbo.RxPatientInfoes", "FamilyHistory");
            DropColumn("dbo.RxPatientInfoes", "PersonalHistory");
            DropColumn("dbo.RxPatientInfoes", "SocioEconomicHistory");
            DropColumn("dbo.RxPatientInfoes", "PsychiatricHistory");
            DropColumn("dbo.RxPatientInfoes", "DrugAndTreatmentHistory");
            DropColumn("dbo.RxPatientInfoes", "AllergyHistory");
            DropColumn("dbo.RxPatientInfoes", "ImmunizationHistory");
            DropColumn("dbo.RxPatientInfoes", "MeanstrualAndObstetricHistory");
            DropColumn("dbo.RxPatientInfoes", "OtherHistory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "OtherHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "MeanstrualAndObstetricHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "ImmunizationHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "AllergyHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "DrugAndTreatmentHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PsychiatricHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "SocioEconomicHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PersonalHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "FamilyHistory", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Pastillness", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Presentillness", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "CCDuration", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "ChiefComplains", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Weight", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPErectBottom", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPErectTop", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPSupineBottom", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BPSupineTop", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Pulse", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "PractitionerId", c => c.Int(nullable: false));
            AddColumn("dbo.RxPatientInfoes", "Id", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.RxPatientInfoes", "CPId", "dbo.ChamberPractitioners");
            DropIndex("dbo.RxPatientInfoes", new[] { "CPId" });
            DropPrimaryKey("dbo.RxPatientInfoes");
            DropColumn("dbo.RxPatientInfoes", "CPId");
            DropColumn("dbo.RxPatientInfoes", "RxId");
            AddPrimaryKey("dbo.RxPatientInfoes", "Id");
        }
    }
}
