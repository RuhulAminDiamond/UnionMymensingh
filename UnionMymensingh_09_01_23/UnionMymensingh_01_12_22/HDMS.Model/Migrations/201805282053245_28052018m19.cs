namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "CabinOrWardBedDisplayString", c => c.String());
            DropColumn("dbo.HospitalPatientInfoes", "WardBedDisplayString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "WardBedDisplayString", c => c.String());
            DropColumn("dbo.HospitalPatientInfoes", "CabinOrWardBedDisplayString");
        }
    }
}
