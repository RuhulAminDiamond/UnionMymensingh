namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m10 : DbMigration
    {
        public override void Up()
        {
           // DropPrimaryKey("dbo.HospitalBillDetails");
            AddColumn("dbo.HospitalBillDetails", "HospitalBillDetailIdddd", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.HospitalBillDetails", "HospitalBillDetailIdddd");
            DropColumn("dbo.HospitalBillDetails", "HospitalBillDetailId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalBillDetails", "HospitalBillDetailId", c => c.Long(nullable: false, identity: true));
            DropPrimaryKey("dbo.HospitalBillDetails");
            DropColumn("dbo.HospitalBillDetails", "HospitalBillDetailIdddd");
            AddPrimaryKey("dbo.HospitalBillDetails", "HospitalBillDetailId");
        }
    }
}
