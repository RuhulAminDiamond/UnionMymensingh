namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBillDetails", "HospitalBillIdss", c => c.Long(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "ServiceNameaa", c => c.String());
            AddColumn("dbo.HospitalBillDetails", "Qtys", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Rates", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Totals", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "DoctorIds", c => c.Int(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "HospitalBillId");
            DropColumn("dbo.HospitalBillDetails", "ServiceName");
            DropColumn("dbo.HospitalBillDetails", "Qty");
            DropColumn("dbo.HospitalBillDetails", "Rate");
            DropColumn("dbo.HospitalBillDetails", "Total");
            DropColumn("dbo.HospitalBillDetails", "DoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalBillDetails", "DoctorId", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Rate", c => c.Double(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.HospitalBillDetails", "ServiceName", c => c.String());
            AddColumn("dbo.HospitalBillDetails", "HospitalBillId", c => c.Long(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "DoctorIds");
            DropColumn("dbo.HospitalBillDetails", "Totals");
            DropColumn("dbo.HospitalBillDetails", "Rates");
            DropColumn("dbo.HospitalBillDetails", "Qtys");
            DropColumn("dbo.HospitalBillDetails", "ServiceNameaa");
            DropColumn("dbo.HospitalBillDetails", "HospitalBillIdss");
        }
    }
}
