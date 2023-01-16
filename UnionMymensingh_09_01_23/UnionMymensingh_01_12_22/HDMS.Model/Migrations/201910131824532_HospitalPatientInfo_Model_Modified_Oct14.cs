namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalPatientInfo_Model_Modified_Oct14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "PackageId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "PackageId");
        }
    }
}
