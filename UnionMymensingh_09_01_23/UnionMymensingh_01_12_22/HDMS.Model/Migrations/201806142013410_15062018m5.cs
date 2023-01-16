namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBillDetails", "HospitalBillId", c => c.Long(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "ServiceName", c => c.String());
            AddColumn("dbo.HospitalBillDetails", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Rate", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "DoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "HospitalBillIdss");
            DropColumn("dbo.HospitalBillDetails", "ServiceNameaa");
            DropColumn("dbo.HospitalBillDetails", "Qtys");
            DropColumn("dbo.HospitalBillDetails", "Rates");
            DropColumn("dbo.HospitalBillDetails", "Totals");
            DropColumn("dbo.HospitalBillDetails", "DoctorIds");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalBillDetails", "DoctorIds", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Totals", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Rates", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Qtys", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "ServiceNameaa", c => c.String());
            AddColumn("dbo.HospitalBillDetails", "HospitalBillIdss", c => c.Long(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "DoctorId");
            DropColumn("dbo.HospitalBillDetails", "Total");
            DropColumn("dbo.HospitalBillDetails", "Rate");
            DropColumn("dbo.HospitalBillDetails", "Qty");
            DropColumn("dbo.HospitalBillDetails", "ServiceName");
            DropColumn("dbo.HospitalBillDetails", "HospitalBillId");
        }
    }
}
