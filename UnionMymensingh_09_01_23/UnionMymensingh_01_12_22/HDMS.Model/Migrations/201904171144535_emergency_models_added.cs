namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emergency_models_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpOPDServiceBills",
                c => new
                    {
                        SBId = c.Long(nullable: false, identity: true),
                        SDate = c.DateTime(nullable: false),
                        ServiceAmount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SBId);
            
            CreateTable(
                "dbo.OPDDoctorServiceBillDetails",
                c => new
                    {
                        DSBDId = c.Long(nullable: false, identity: true),
                        DSBId = c.Long(nullable: false),
                        PatientId = c.Long(nullable: false),
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
                .ForeignKey("dbo.ServiceHeads", t => t.ServiceHeadId, cascadeDelete: true)
                .Index(t => t.ServiceHeadId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.OPDServiceBillDetails",
                c => new
                    {
                        SBDId = c.Long(nullable: false, identity: true),
                        SBId = c.Long(nullable: false),
                        PatientId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Int(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        ServiceDate = c.DateTime(nullable: false),
                        ServiceTime = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SBDId);
            
            AddColumn("dbo.HospitalPatientInfoes", "OPDBillNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OPDDoctorServiceBillDetails", "ServiceHeadId", "dbo.ServiceHeads");
            DropForeignKey("dbo.OPDDoctorServiceBillDetails", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.OPDDoctorServiceBillDetails", new[] { "DoctorId" });
            DropIndex("dbo.OPDDoctorServiceBillDetails", new[] { "ServiceHeadId" });
            DropColumn("dbo.HospitalPatientInfoes", "OPDBillNo");
            DropTable("dbo.OPDServiceBillDetails");
            DropTable("dbo.OPDDoctorServiceBillDetails");
            DropTable("dbo.HpOPDServiceBills");
        }
    }
}
