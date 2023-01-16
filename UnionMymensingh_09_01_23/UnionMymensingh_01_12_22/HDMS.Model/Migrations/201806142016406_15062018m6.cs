namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBillDetails", "DisplayOrders", c => c.Int(nullable: false));
            CreateIndex("dbo.HospitalBillDetails", "HospitalBillId");
            AddForeignKey("dbo.HospitalBillDetails", "HospitalBillId", "dbo.HospitalBills", "HospitalBillId", cascadeDelete: true);
            DropColumn("dbo.HospitalBillDetails", "DisplayOrder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalBillDetails", "DisplayOrder", c => c.Int(nullable: false));
            DropForeignKey("dbo.HospitalBillDetails", "HospitalBillId", "dbo.HospitalBills");
            DropIndex("dbo.HospitalBillDetails", new[] { "HospitalBillId" });
            DropColumn("dbo.HospitalBillDetails", "DisplayOrders");
        }
    }
}
