namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RxPatientInfo_Modified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RxPatientInfoes", "Pulse", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "BP", c => c.String());
            AddColumn("dbo.RxPatientInfoes", "Weight", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "OnExamination");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RxPatientInfoes", "OnExamination", c => c.String());
            DropColumn("dbo.RxPatientInfoes", "Weight");
            DropColumn("dbo.RxPatientInfoes", "BP");
            DropColumn("dbo.RxPatientInfoes", "Pulse");
        }
    }
}
