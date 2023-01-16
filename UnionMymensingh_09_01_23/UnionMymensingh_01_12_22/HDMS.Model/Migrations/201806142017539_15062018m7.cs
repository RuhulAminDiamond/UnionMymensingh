namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBillDetails", "DisplayOrder", c => c.Int(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "DisplayOrders");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalBillDetails", "DisplayOrders", c => c.Int(nullable: false));
            DropColumn("dbo.HospitalBillDetails", "DisplayOrder");
        }
    }
}
