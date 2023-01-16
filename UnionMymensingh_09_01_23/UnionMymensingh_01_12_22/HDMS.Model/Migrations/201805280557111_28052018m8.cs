namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "BillNo", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "BillNo");
        }
    }
}
