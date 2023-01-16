namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OPD_Patient_Record_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OPDPatientRecords",
                c => new
                    {
                        PatientId = c.Long(nullable: false, identity: true),
                        BillNo = c.Long(nullable: false),
                        RegNo = c.Long(nullable: false),
                        AdmissionNo = c.Long(nullable: false),
                        DailyId = c.Int(nullable: false),
                        ReportIdPrefix = c.String(),
                        ReportId = c.Long(nullable: false),
                        RxId = c.Long(nullable: false),
                        AgeYear = c.String(),
                        AgeMonth = c.String(),
                        AgeDay = c.String(),
                        DiscountCareOf = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        EntryTime = c.String(),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryTime = c.String(),
                        DoctorId = c.Int(nullable: false),
                        DiscountRequestById = c.Int(nullable: false),
                        DiscountGivenByRequestInPercent = c.Double(nullable: false),
                        Cabin = c.String(),
                        DiscountInPercent = c.Double(nullable: false),
                        Status = c.String(),
                        Cancelledby = c.String(),
                        CancelledhostIp = c.String(),
                        Cancelledhostname = c.String(),
                        Isfree = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        Updateby = c.Int(nullable: false),
                        CreatedWorkStationId = c.String(),
                        UpdatedWorkStationId = c.String(),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDPatientRecords", "UserId", "dbo.User");
            DropForeignKey("dbo.OPDPatientRecords", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.OPDPatientRecords", new[] { "UserId" });
            DropIndex("dbo.OPDPatientRecords", new[] { "DoctorId" });
            DropTable("dbo.OPDPatientRecords");
        }
    }
}
