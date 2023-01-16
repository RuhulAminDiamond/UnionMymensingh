namespace HDMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28062018m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "ReportIdPrefix", c => c.String());
            AddColumn("dbo.Patients", "ReportId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "ReportId");
            DropColumn("dbo.Patients", "ReportIdPrefix");
        }
    }
}
