namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model_RxPatientHistory_RxPatientPhysicalExam_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxPatientHistories",
                c => new
                    {
                        RPHId = c.Long(nullable: false, identity: true),
                        RxId = c.Long(nullable: false),
                        ChiefComplains = c.String(),
                        CCDuration = c.String(),
                        Presentillness = c.String(),
                        Pastillness = c.String(),
                        FamilyHistory = c.String(),
                        PersonalHistory = c.String(),
                        SocioEconomicHistory = c.String(),
                        PsychiatricHistory = c.String(),
                        DrugAndTreatmentHistory = c.String(),
                        AllergyHistory = c.String(),
                        ImmunizationHistory = c.String(),
                        MeanstrualAndObstetricHistory = c.String(),
                        OtherHistory = c.String(),
                    })
                .PrimaryKey(t => t.RPHId)
                .ForeignKey("dbo.RxPatientInfoes", t => t.RxId, cascadeDelete: true)
                .Index(t => t.RxId);
            
            CreateTable(
                "dbo.RxPatientPhysicalExams",
                c => new
                    {
                        RPEId = c.Long(nullable: false, identity: true),
                        RxId = c.Long(nullable: false),
                        Appearance = c.String(),
                        Nutrition = c.String(),
                        Decubitus = c.String(),
                        Cooperation = c.String(),
                        Anaemia = c.String(),
                        Jaundice = c.String(),
                        Cyanosis = c.String(),
                        Clubbing = c.String(),
                        Koilonychia = c.String(),
                        Leukonychia = c.String(),
                        Oedema = c.String(),
                        Dehydration = c.String(),
                        Bonytenderness = c.String(),
                        Pigmentation = c.String(),
                        Lymphnodes = c.String(),
                        Thyroidgland = c.String(),
                        Breasts = c.String(),
                        Bodyhair = c.String(),
                        Pulse = c.String(),
                        BPCystol = c.String(),
                        BPDiastol = c.String(),
                        Weight = c.String(),
                        WeightUnit = c.String(),
                        Temperature = c.String(),
                        Respirtaion = c.String(),
                        Neck = c.String(),
                        Axilla = c.String(),
                        Head = c.String(),
                        Rash = c.String(),
                        Scarmark = c.String(),
                        Scratchmark = c.String(),
                    })
                .PrimaryKey(t => t.RPEId)
                .ForeignKey("dbo.RxPatientInfoes", t => t.RxId, cascadeDelete: true)
                .Index(t => t.RxId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxPatientPhysicalExams", "RxId", "dbo.RxPatientInfoes");
            DropForeignKey("dbo.RxPatientHistories", "RxId", "dbo.RxPatientInfoes");
            DropIndex("dbo.RxPatientPhysicalExams", new[] { "RxId" });
            DropIndex("dbo.RxPatientHistories", new[] { "RxId" });
            DropTable("dbo.RxPatientPhysicalExams");
            DropTable("dbo.RxPatientHistories");
        }
    }
}
