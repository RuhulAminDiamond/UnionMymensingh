namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HpPatientAccomodationInfo_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HpPatientAccomodationInfoes", "StayingDurationInHours", c => c.Double(nullable: false));
            CreateIndex("dbo.HpPatientAccomodationInfoes", "AdmissionId");
            AddForeignKey("dbo.HpPatientAccomodationInfoes", "AdmissionId", "dbo.HospitalPatientInfoes", "AdmissionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HpPatientAccomodationInfoes", "AdmissionId", "dbo.HospitalPatientInfoes");
            DropIndex("dbo.HpPatientAccomodationInfoes", new[] { "AdmissionId" });
            DropColumn("dbo.HpPatientAccomodationInfoes", "StayingDurationInHours");
        }
    }
}
