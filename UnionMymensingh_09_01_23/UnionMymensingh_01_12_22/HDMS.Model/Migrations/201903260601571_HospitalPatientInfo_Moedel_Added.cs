namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HospitalPatientInfo_Moedel_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "MediaId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "MediaId");
        }
    }
}
