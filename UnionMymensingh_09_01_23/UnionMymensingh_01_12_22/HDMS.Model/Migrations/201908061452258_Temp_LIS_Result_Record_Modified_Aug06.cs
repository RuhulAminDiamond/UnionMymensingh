namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Temp_LIS_Result_Record_Modified_Aug06 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TEMP_LIS_ResultRecord", "ReportDefId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TEMP_LIS_ResultRecord", "ReportDefId");
        }
    }
}
