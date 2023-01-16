namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBills", "BillTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalBills", "BillTime");
        }
    }
}
