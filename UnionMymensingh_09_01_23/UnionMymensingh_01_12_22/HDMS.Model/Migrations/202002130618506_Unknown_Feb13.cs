namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unknown_Feb13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PathologyNonWordReportReportDetails", "MachineResult", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PathologyNonWordReportReportDetails", "MachineResult");
        }
    }
}
