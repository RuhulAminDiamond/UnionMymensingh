namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PathologyReport_Model_Mdofied_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologyReports", "ReportTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologyReports", "ReportTime");
        }
    }
}
