namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m24 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.HospitalBillDetails");
            AddColumn("dbo.HospitalBillDetails", "HospitalBillDetailId", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.HpPatientLedgerFinals", "HospitalBillId", c => c.Long(nullable: false));
            AlterColumn("dbo.HospitalBills", "BillNo", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.HospitalBillDetails", "HospitalBillDetailId");
            CreateIndex("dbo.HpPatientLedgerFinals", "HospitalBillId");
            AddForeignKey("dbo.HpPatientLedgerFinals", "HospitalBillId", "dbo.HospitalBills", "HospitalBillId", cascadeDelete: true);
            DropColumn("dbo.HospitalBillDetails", "HospitalBillDetailIdddd");
            DropColumn("dbo.HpPatientLedgerFinals", "AdmissionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpPatientLedgerFinals", "AdmissionId", c => c.Long(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "HospitalBillDetailIdddd", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.HpPatientLedgerFinals", "HospitalBillId", "dbo.HospitalBills");
            DropIndex("dbo.HpPatientLedgerFinals", new[] { "HospitalBillId" });
            DropPrimaryKey("dbo.HospitalBillDetails");
            AlterColumn("dbo.HospitalBills", "BillNo", c => c.String());
            DropColumn("dbo.HpPatientLedgerFinals", "HospitalBillId");
            DropColumn("dbo.HospitalBillDetails", "HospitalBillDetailId");
            AddPrimaryKey("dbo.HospitalBillDetails", "HospitalBillDetailIdddd");
        }
    }
}
