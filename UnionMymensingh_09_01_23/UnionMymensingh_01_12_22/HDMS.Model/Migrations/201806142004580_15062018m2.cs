namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBillDetails", "ServiceHeadId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalBillDetails", "ServiceHeadId");
        }
    }
}
