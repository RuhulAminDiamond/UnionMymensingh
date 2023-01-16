namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22062018m1001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "CreatedWorkStationId", c => c.String());
            AddColumn("dbo.HospitalPatientInfoes", "UpdatedWorkStationId", c => c.String());
            AddColumn("dbo.Patients", "CreatedWorkStationId", c => c.String());
            AddColumn("dbo.Patients", "UpdatedWorkStationId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "UpdatedWorkStationId");
            DropColumn("dbo.Patients", "CreatedWorkStationId");
            DropColumn("dbo.HospitalPatientInfoes", "UpdatedWorkStationId");
            DropColumn("dbo.HospitalPatientInfoes", "CreatedWorkStationId");
        }
    }
}
