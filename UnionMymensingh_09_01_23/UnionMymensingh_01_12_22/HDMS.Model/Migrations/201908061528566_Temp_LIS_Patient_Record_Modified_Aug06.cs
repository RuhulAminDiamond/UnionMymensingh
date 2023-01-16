namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_LIS_Patient_Record_Modified_Aug06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TEMP_LIS_PatientRecord", "ReportId", c => c.String());
            AlterColumn("dbo.TEMP_LIS_PatientRecord", "PatientId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TEMP_LIS_PatientRecord", "PatientId", c => c.String());
            DropColumn("dbo.TEMP_LIS_PatientRecord", "ReportId");
        }
    }
}
