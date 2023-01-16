namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0604201897 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HospitalPatientInfoes", "Admittedby", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HospitalPatientInfoes", "Admittedby");
        }
    }
}
