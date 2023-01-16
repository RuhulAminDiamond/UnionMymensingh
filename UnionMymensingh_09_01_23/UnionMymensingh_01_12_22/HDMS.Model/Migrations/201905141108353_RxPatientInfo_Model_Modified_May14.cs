namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientInfo_Model_Modified_May14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "CCDuration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RxPatientInfoes", "CCDuration");
        }
    }
}
