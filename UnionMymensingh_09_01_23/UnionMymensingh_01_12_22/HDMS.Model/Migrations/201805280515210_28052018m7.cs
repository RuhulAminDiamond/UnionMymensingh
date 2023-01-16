namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28052018m7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HospitalPatientInfoes", "AdmissionFee", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HospitalPatientInfoes", "AdmissionFee", c => c.Int(nullable: false));
        }
    }
}
