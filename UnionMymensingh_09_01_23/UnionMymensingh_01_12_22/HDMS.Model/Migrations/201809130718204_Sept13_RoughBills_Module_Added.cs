namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sept13_RoughBills_Module_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HospitalRoughBillDetails",
                c => new
                    {
                        HospitalRoughBillDetailId = c.Long(nullable: false, identity: true),
                        HospitalRoughBillId = c.Long(nullable: false),
                        ServiceHeadId = c.Int(nullable: false),
                        ServiceName = c.String(),
                        Qty = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalRoughBillDetailId)
                .ForeignKey("dbo.HospitalRoughBills", t => t.HospitalRoughBillId, cascadeDelete: true)
                .Index(t => t.HospitalRoughBillId);
            
            CreateTable(
                "dbo.HospitalRoughBills",
                c => new
                    {
                        HospitalRoughBillId = c.Long(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        BillTime = c.String(),
                        AdmissionId = c.Long(nullable: false),
                        BillNo = c.Long(nullable: false),
                        PreparedBy = c.String(),
                        BillType = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.HospitalRoughBillId);
            
            CreateTable(
                "dbo.HpPatientLedgerRoughs",
                c => new
                    {
                        TranId = c.Long(nullable: false, identity: true),
                        HospitalRoughBillId = c.Long(nullable: false),
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
                .ForeignKey("dbo.HospitalRoughBills", t => t.HospitalRoughBillId, cascadeDelete: true)
                .Index(t => t.HospitalRoughBillId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpPatientLedgerRoughs", "HospitalRoughBillId", "dbo.HospitalRoughBills");
            DropForeignKey("dbo.HospitalRoughBillDetails", "HospitalRoughBillId", "dbo.HospitalRoughBills");
            DropIndex("dbo.HpPatientLedgerRoughs", new[] { "HospitalRoughBillId" });
            DropIndex("dbo.HospitalRoughBillDetails", new[] { "HospitalRoughBillId" });
            DropTable("dbo.HpPatientLedgerRoughs");
            DropTable("dbo.HospitalRoughBills");
            DropTable("dbo.HospitalRoughBillDetails");
        }
    }
}
