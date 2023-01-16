namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalPatientInfo_StatusChangeby_columnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "StatusChangeBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "StatusChangeBy");
        }
    }
}
