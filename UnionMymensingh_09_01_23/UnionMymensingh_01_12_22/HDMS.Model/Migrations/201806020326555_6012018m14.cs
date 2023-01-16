namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6012018m14 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.HospitalPatientInfoes", "AdmissionFee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HospitalPatientInfoes", "AdmissionFee", c => c.Double(nullable: false));
        }
    }
}
