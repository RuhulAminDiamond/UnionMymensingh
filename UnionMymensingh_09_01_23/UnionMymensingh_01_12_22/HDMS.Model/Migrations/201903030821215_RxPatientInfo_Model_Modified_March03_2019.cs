namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientInfo_Model_Modified_March03_2019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "PractitionerId", c => c.Int(nullable: false));
            AddColumn("dbo.RxPatientInfoes", "PractitionerRefdDoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.RxPatientInfoes", "RxDoctorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "RxDoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.RxPatientInfoes", "PractitionerRefdDoctorId");
            DropColumn("dbo.RxPatientInfoes", "PractitionerId");
        }
    }
}
