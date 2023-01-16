namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15062018m44 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalBills", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalBills", "Remarks");
        }
    }
}
