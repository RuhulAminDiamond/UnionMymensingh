namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HospitalBillDetails",
                c => new
                    {
                        HospitalBillDetailId = c.Long(nullable: false, identity: true),
                        HospitalBillId = c.Long(nullable: false),
                        ServiceName = c.String(),
                        Qty = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        DisplayOrder = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HospitalBillDetailId);
            
            CreateTable(
                "dbo.HospitalBills",
                c => new
                    {
                        HospitalBillId = c.Long(nullable: false, identity: true),
                        Billdate = c.DateTime(nullable: false),
                        AdmissionId = c.Long(nullable: false),
                        BillNo = c.String(),
                        PreparedBy = c.String(),
                    })
                .PrimaryKey(t => t.HospitalBillId);
            
            AddColumn("dbo.TestItems", "ShortName", c => c.String());
            DropTable("dbo.HospitalBilldetails");
            DropTable("dbo.HospitalBillingItems");
            DropTable("dbo.HospitlBills");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HospitlBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNo = c.String(),
                        Billby = c.String(),
                        Invdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalBillingItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rate = c.Double(nullable: false),
                        IserviceCharge = c.String(),
                        IsVat = c.String(),
                        IsReferralCommission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HospitalBilldetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        BillItemId = c.Int(nullable: false),
                        DeliveredUnit = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        ReportOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.TestItems", "ShortName");
            DropTable("dbo.HospitalBills");
            DropTable("dbo.HospitalBillDetails");
        }
    }
}
