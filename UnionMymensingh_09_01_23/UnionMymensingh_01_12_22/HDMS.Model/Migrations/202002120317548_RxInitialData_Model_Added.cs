namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxInitialData_Model_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RxInitialDatas",
                c => new
                    {
                        RxInitDId = c.Long(nullable: false, identity: true),
                        RegNo = c.Long(nullable: false),
                        CpId = c.Int(nullable: false),
                        RxDate = c.DateTime(nullable: false),
                        RxTime = c.String(),
                        SpecilaAlert = c.String(),
                        Confidential = c.String(),
                        PastHistory = c.String(),
                        Additional = c.String(),
                        TreatmentPaln = c.String(),
                        Prescription = c.String(),
                        WeightInKg = c.String(),
                        Height = c.String(),
                        HeightUnit = c.String(),
                        BpErrectTop = c.String(),
                        BpErrectBottom = c.String(),
                        BpSupineTop = c.String(),
                        BpSupineBottom = c.String(),
                        Pulse = c.String(),
                        PulseBehaviour1 = c.String(),
                        PulseBehaviour2 = c.String(),
                        OtherFindings = c.String(),
                        DrugHistory = c.String(),
                        IsSketchAvailable = c.Boolean(nullable: false),
                        Diagnosis = c.String(),
                        FollowUpOn = c.DateTime(),
                        FollowUpAfter = c.String(),
                    })
                .PrimaryKey(t => t.RxInitDId);
            
            AddColumn("dbo.RxPatientInfoes", "RxInitDId", c => c.Long(nullable: false));
            AddColumn("dbo.RxTests", "RxInitDId", c => c.Long(nullable: false));
            CreateIndex("dbo.RxPatientInfoes", "RxInitDId");
            AddForeignKey("dbo.RxPatientInfoes", "RxInitDId", "dbo.RxInitialDatas", "RxInitDId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RxPatientInfoes", "RxInitDId", "dbo.RxInitialDatas");
            DropIndex("dbo.RxPatientInfoes", new[] { "RxInitDId" });
            DropColumn("dbo.RxTests", "RxInitDId");
            DropColumn("dbo.RxPatientInfoes", "RxInitDId");
            DropTable("dbo.RxInitialDatas");
        }
    }
}
