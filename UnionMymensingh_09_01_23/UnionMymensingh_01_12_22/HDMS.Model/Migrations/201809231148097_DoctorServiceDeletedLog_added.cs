namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorServiceDeletedLog_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorServiceDeletedLogs",
                c => new
                    {
                        DSBDId = c.Long(nullable: false, identity: true),
                        DSBId = c.Long(nullable: false),
                        AdmissionId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        Vat = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DSBDId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
               // .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.AdmissionId)
                .Index(t => t.ServiceHeadId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorServiceDeletedLogs", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.DoctorServiceDeletedLogs", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropForeignKey("dbo.DoctorServiceDeletedLogs", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.DoctorServiceDeletedLogs", new[] { "DoctorId" });
            DropIndex("dbo.DoctorServiceDeletedLogs", new[] { "ServiceHeadId" });
            DropIndex("dbo.DoctorServiceDeletedLogs", new[] { "AdmissionId" });
            DropTable("dbo.DoctorServiceDeletedLogs");
        }
    }
}
