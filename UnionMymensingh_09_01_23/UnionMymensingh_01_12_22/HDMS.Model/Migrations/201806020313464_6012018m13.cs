namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6012018m13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HpAdmissionFees",
                c => new
                    {
                        HpAdmissionFeeId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.HpAdmissionFeeId);
            
            CreateTable(
                "dbo.HpConsultantLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.TranId)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.HpPatientLedgers",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        AdmissionId = c.Long(nullable: false),
                        TranDate = c.DateTime(nullable: false),
                        Particulars = c.String(),
                        Debit = c.Double(nullable: false),
                        Credit = c.Double(nullable: false),
                        Balance = c.Double(nullable: false),
                        TransactionType = c.String(),
                        Remarks = c.String(),
                        OperateBy = c.String(),
                    })
                .PrimaryKey(t => t.TranId)
                .ForeignKey("dbo.HospitalPatientInfoes", t => t.AdmissionId, cascadeDelete: true)
                .Index(t => t.AdmissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpPatientLedgers", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropForeignKey("dbo.HpConsultantLedgers", "DoctorId", "dbo.Doctor");
            DropIndex("dbo.HpPatientLedgers", new[] { "AdmissionId" });
            DropIndex("dbo.HpConsultantLedgers", new[] { "DoctorId" });
            DropTable("dbo.HpPatientLedgers");
            DropTable("dbo.HpConsultantLedgers");
            DropTable("dbo.HpAdmissionFees");
        }
    }
}
