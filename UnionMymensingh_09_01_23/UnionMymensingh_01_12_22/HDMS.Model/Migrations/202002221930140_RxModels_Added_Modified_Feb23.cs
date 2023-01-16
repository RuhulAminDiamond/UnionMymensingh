namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxModels_Added_Modified_Feb23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RxPatientInfoes", "CPId", "dbo.ChamberPractitioners");
            DropForeignKey("dbo.RxPatientInfoes", "RxInitDId", "dbo.RxInitialDatas");
            DropForeignKey("dbo.RxPatientHistories", "RxId", "dbo.RxPatientInfoes");
            DropForeignKey("dbo.RxPatientPhysicalExams", "RxId", "dbo.RxPatientInfoes");
            DropIndex("dbo.RxPatientHistories", new[] { "RxId" });
            DropIndex("dbo.RxPatientInfoes", new[] { "RxInitDId" });
            DropIndex("dbo.RxPatientInfoes", new[] { "CPId" });
            DropIndex("dbo.RxPatientPhysicalExams", new[] { "RxId" });
            CreateTable(
                "dbo.RxSavedAdvices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        AdviceEn = c.String(),
                        AdviceBn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RxPatientMasterDatas",
                c => new
                    {
                        RxPMId = c.Long(nullable: false, identity: true),
                        RegNo = c.Long(nullable: false),
                        RxMasterDataDate = c.DateTime(nullable: false),
                        RxInitDId = c.Long(nullable: false),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        OperateBy = c.Int(nullable: false),
                        IsServiceDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RxPMId)
                .ForeignKey("dbo.RxInitialDatas", t => t.RxInitDId, cascadeDelete: true)
                .Index(t => t.RxInitDId);
            
            CreateTable(
                "dbo.RxVisitHistories",
                c => new
                    {
                        RxVisitId = c.Long(nullable: false, identity: true),
                        RxPMId = c.Long(nullable: false),
                        CpId = c.Int(nullable: false),
                        VisitNo = c.Int(nullable: false),
                        VisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RxVisitId);
            
            DropTable("dbo.RxAdvices");
            DropTable("dbo.RxPatientHistories");
            DropTable("dbo.RxPatientInfoes");
            DropTable("dbo.RxPatientPhysicalExams");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.RPEId);
            
            CreateTable(
                "dbo.RxPatientInfoes",
                c => new
                    {
                        RxId = c.Long(nullable: false, identity: true),
                        RxInitDId = c.Long(nullable: false),
                        CPId = c.Int(nullable: false),
                        PractitionerRefdDoctorId = c.Int(nullable: false),
                        RxDate = c.DateTime(nullable: false),
                        RxTime = c.String(),
                        RegNo = c.Long(nullable: false),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        VisitStatus = c.String(),
                        AnySpecialNote = c.String(),
                        PatientType = c.String(),
                        Diagnosis = c.String(),
                        OperateBy = c.Int(nullable: false),
                        IsServiceDelivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RxId);
            
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
                .PrimaryKey(t => t.RPHId);
            
            CreateTable(
                "dbo.RxAdvices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPId = c.Int(nullable: false),
                        Advice = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RxPatientMasterDatas", "RxInitDId", "dbo.RxInitialDatas");
            DropIndex("dbo.RxPatientMasterDatas", new[] { "RxInitDId" });
            DropTable("dbo.RxVisitHistories");
            DropTable("dbo.RxPatientMasterDatas");
            DropTable("dbo.RxSavedAdvices");
            CreateIndex("dbo.RxPatientPhysicalExams", "RxId");
            CreateIndex("dbo.RxPatientInfoes", "CPId");
            CreateIndex("dbo.RxPatientInfoes", "RxInitDId");
            CreateIndex("dbo.RxPatientHistories", "RxId");
            AddForeignKey("dbo.RxPatientPhysicalExams", "RxId", "dbo.RxPatientInfoes", "RxId", cascadeDelete: true);
            AddForeignKey("dbo.RxPatientHistories", "RxId", "dbo.RxPatientInfoes", "RxId", cascadeDelete: true);
            AddForeignKey("dbo.RxPatientInfoes", "RxInitDId", "dbo.RxInitialDatas", "RxInitDId", cascadeDelete: true);
            AddForeignKey("dbo.RxPatientInfoes", "CPId", "dbo.ChamberPractitioners", "CPId", cascadeDelete: true);
        }
    }
}
