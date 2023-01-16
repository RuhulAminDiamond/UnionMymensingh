namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _09062018m902 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegRecords", "SpouseName", c => c.String());
            DropColumn("dbo.HospitalPatientInfoes", "GurdianType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "GurdianType", c => c.String());
            DropColumn("dbo.RegRecords", "SpouseName");
        }
    }
}
