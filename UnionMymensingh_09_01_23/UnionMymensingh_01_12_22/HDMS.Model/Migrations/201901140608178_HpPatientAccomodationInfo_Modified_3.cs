namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPatientAccomodationInfo_Modified_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPatientAccomodationInfoes", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.HpPatientAccomodationInfoes", "ReleaseTime", c => c.String());
            DropColumn("dbo.HpPatientAccomodationInfoes", "StayingDurationInHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HpPatientAccomodationInfoes", "StayingDurationInHours", c => c.Double(nullable: false));
            DropColumn("dbo.HpPatientAccomodationInfoes", "ReleaseTime");
            DropColumn("dbo.HpPatientAccomodationInfoes", "ReleaseDate");
        }
    }
}
