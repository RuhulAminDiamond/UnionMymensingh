namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "WardBedDisplayString", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "WardBedDisplayString");
        }
    }
}
