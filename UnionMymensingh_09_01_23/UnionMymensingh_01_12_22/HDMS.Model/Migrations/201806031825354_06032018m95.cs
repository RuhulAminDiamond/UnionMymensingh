namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06032018m95 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "BloodGroup", c => c.String());
            DropColumn("dbo.HospitalPatientInfoes", "GurdianName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "GurdianName", c => c.String());
            DropColumn("dbo.RegRecords", "BloodGroup");
        }
    }
}
